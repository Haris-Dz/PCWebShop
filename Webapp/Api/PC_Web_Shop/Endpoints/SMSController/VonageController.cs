using Microsoft.AspNetCore.Mvc;
using Vonage;
using Vonage.Request;
using System.Threading.Tasks;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;

[Route("api/[controller]")]
[ApiController]
public class VonageController : ControllerBase
{
    private readonly VonageClient _vonageClient;
    private readonly ApplicationDbContext _applicationDbContext;
    public VonageController(ApplicationDbContext applicationDbContext)
    {
        var credentials = Credentials.FromApiKeyAndSecret("425b49a8", "7WgDGqZWqXcTXNS8");
        _vonageClient = new VonageClient(credentials);
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("send-sms")]
    public async Task<IActionResult> SendSms([FromBody] SmsRequest request)
    {
        var response = await _vonageClient.SmsClient.SendAnSmsAsync(new Vonage.Messaging.SendSmsRequest
        {
            To = request.To,
            From = "YOUR_VONAGE_NUMBER",
            Text = request.Text
        });
        SmsLog smszapis = new SmsLog();
        smszapis.Broj = request.To;
        smszapis.Poruka = request.Text;
        if (response.Messages[0].Status == "0")
        {
            _applicationDbContext.Add(smszapis);
            _applicationDbContext.SaveChanges();
            return Ok();
        }
        else
        {
            return StatusCode(500, $"Message failed with error: {response.Messages[0].ErrorText}");
        }
    }
}

public class SmsRequest
{
    public string To { get; set; }
    public string Text { get; set; }
}