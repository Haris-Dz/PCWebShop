using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.KupacEndpoints.PromjenaLozinkeEndpoint
{
    [Route("kupac")]
    public class PromjenaLozinkeEndpoint:MyBaseEndpoint<PromjenaLozinkeRequest,ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public PromjenaLozinkeEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
            _myAuthService = myAuthService;
        }
        [HttpPut("promijeni/{Id}")]
        public override async Task<ActionResult> Obradi([FromBody] PromjenaLozinkeRequest request, CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!(korisnickiNalog.isKupac || korisnickiNalog.isAdmin || korisnickiNalog.isZaposlenik))
            {

                return Unauthorized("Nije autorizovan");

            }
            Data.Models.KorisnickiNalog? _odabraniKorisnickiNalog;

            _odabraniKorisnickiNalog = _applicationDbContext.KorisnickiNalog.FirstOrDefault(x => x.Id == request.Id);
            if (_odabraniKorisnickiNalog == null)
            {
                return BadRequest("Pogresan ID");
            }

            var staralozinka = request.Staralozinka.HashirajSHA256();
            var novalozinka = request.Novalozinka.HashirajSHA256();

            if (staralozinka != _odabraniKorisnickiNalog.Lozinka)
            {
                return BadRequest("Pogresna lozinka");
            }
            else
            {
                _odabraniKorisnickiNalog.Lozinka = novalozinka;
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return Ok(_odabraniKorisnickiNalog.Id);
            }
        }
    }
}
