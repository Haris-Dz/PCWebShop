
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;
using Stripe;
using Stripe.Checkout;


[ApiController]
[Route("api/[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly StripeSettings _stripeSettings;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _myAuthService;
    public CheckoutController(IOptions<StripeSettings> stripeSettings,ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
    {
        _myAuthService = myAuthService;
        _applicationDbContext = applicationDbContext;
        _stripeSettings = stripeSettings.Value;
        StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
    }

    [HttpPost("create-checkout-session")]
    public IActionResult CreateCheckoutSession(int IdNarudzbe)
    {
        if (!_myAuthService.IsLogiran())
        {
            return Unauthorized("Nije logiran");
        }
        var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
        if (!(korisnickiNalog.isKupac))
        {

            return Unauthorized("Nije autorizovan");

        }
        var narudzba = _applicationDbContext.Narudzba.SingleOrDefault(x=>x.Id == IdNarudzbe);
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "bam",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Narudzba",
                        },
                        UnitAmount = (long)(narudzba.UkupnaCijena * 100),
                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl =Config.WebURL+ "/#/narudzba-success/" + narudzba.Id,
            CancelUrl =Config.WebURL + "/#/upravljanje-narudzbama/" + narudzba.Id,
        };

        var service = new SessionService();
        Session session = service.Create(options);

        return Ok(new { id = session.Id });
    }
}