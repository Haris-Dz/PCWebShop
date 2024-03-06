
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.PopustEndpoints.PopustDodaj
{
    [Route("popust")]

    public class PopustDodajEndpoint:MyBaseEndpoint<PopustDodajRequest, ActionResult>
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public PopustDodajEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("dodaj")]

        public override async Task<ActionResult> Obradi(PopustDodajRequest request, CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!(korisnickiNalog.isAdmin || korisnickiNalog.isZaposlenik))
            {

                return Unauthorized("Nije autorizovan");

            }
            Data.Models.Popust? novipopust;
            novipopust = new Data.Models.Popust();
            _applicationDbContext.Add(novipopust);

            novipopust.Naziv=request.Naziv;
            novipopust.DatumDo=request.DatumDo;
            novipopust.DatumOd=request.DatumOd;
            novipopust.Procenat=request.Procenat;
   

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            
            return Ok(novipopust);

        }
    }
}
