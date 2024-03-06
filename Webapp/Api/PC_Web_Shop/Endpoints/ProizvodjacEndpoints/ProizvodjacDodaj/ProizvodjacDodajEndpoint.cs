
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.ProizvodjacEndpoints.ProizvodjacDodaj
{
    [Route("proizvodjac")]
    public class ProizvodjacDodajEndpoint:MyBaseEndpoint<ProizvodjacDodajRequest, ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;


        public ProizvodjacDodajEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost("dodaj")]
        public override async Task<ActionResult>Obradi(ProizvodjacDodajRequest request, CancellationToken cancellationToken)
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
            Proizvodjac? noviproizvodjac;
            noviproizvodjac= new Proizvodjac();
            _applicationDbContext.Add(noviproizvodjac);

            noviproizvodjac.Naziv = request.Naziv;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

           
            return Ok(noviproizvodjac);
        }
           
          

    }
}
