using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.EmailController
{
    public class EmailController:ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] Email emailModel)
        {
            await _emailService.SendEmailAsync(emailModel);
            return Ok();
        }
    }
}
