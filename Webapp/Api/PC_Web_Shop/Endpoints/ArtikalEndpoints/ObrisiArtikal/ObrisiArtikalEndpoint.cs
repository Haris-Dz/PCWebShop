using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;


namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.ObrisiArtikal
{
    [Route("artikal")]
    public class ObrisiArtikalEndpoint:MyBaseEndpoint<int, ActionResult >
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public ObrisiArtikalEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut("obrisi/{Id}")]
        public override async Task<ActionResult> Obradi([FromRoute]int Id, CancellationToken cancellationToken)
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
            Artikal? _odabraniArtikal;

            _odabraniArtikal = _applicationDbContext.Artikal.FirstOrDefault(x => x.Id == Id);
            if (_odabraniArtikal == null)
            {
                return BadRequest("Pogresan ID");
            }
            _odabraniArtikal.IsDeleted=true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(_odabraniArtikal.Id);
        }


    }
}
