using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.ZaposlenikDodajEndpoint;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.ZaposlenikUrediEndpoint
{
    [Route("Zaposlenici")]
    public class ZaposlenikUrediEndpoint:MyBaseEndpoint<ZaposlenikUrediRequest,ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public ZaposlenikUrediEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _myAuthService = authService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPut("uredi/{Id}")]
        public override async Task<ActionResult> Obradi([FromBody]ZaposlenikUrediRequest request, CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!korisnickiNalog.isAdmin)
            {

                return Unauthorized("Nije autorizovan");

            }

            var _odabraniZaposlenik = _applicationDbContext.Zaposlenik.Find(request.Id);
            if (_odabraniZaposlenik == null)
            {
                return BadRequest("Pogresan ID");
            }
            
            _odabraniZaposlenik.Ime = request.Ime;
            _odabraniZaposlenik.Prezime=request.Prezime;
            _odabraniZaposlenik.Ulica=request.Ulica;
            _odabraniZaposlenik.BrojMobitela = request.BrojMobitela;
            _odabraniZaposlenik.GradId=request.GradId;


            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Ok(_odabraniZaposlenik.Id);
        }
    }
}
