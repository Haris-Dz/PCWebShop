
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;
using System.Security.AccessControl;

namespace PC_Web_Shop.Endpoints.ProizvodjacEndpoints.ProizvodjacObrisi
{
    [Route("Proizvodjac")]
    public class ProizvodjacObrisiEndpoint:MyBaseEndpoint<ProizvodjacObrisiRequest, ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public ProizvodjacObrisiEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
            _myAuthService = myAuthService;
        }
        [HttpPut("Obrisi")]
        public override async Task<ActionResult> Obradi([FromBody] ProizvodjacObrisiRequest request, CancellationToken cancellationToken)
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
            Proizvodjac? odabraniproizvodjac;
            odabraniproizvodjac=_applicationDbContext.Proizvodjac.FirstOrDefault(x=>x.Id==request.Id);
            if (odabraniproizvodjac == null)
            {
                throw new Exception("POgresan ID");
            }
            odabraniproizvodjac.IsDeleted = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return Ok(odabraniproizvodjac.Id);

        }
    }
}
