using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.KupacEndpoints.KupacUrediEndpoint
{
    [Route("kupac")]
    public class KupacUrediEndpoint:MyBaseEndpoint<KupacUrediRequest,ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public KupacUrediEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
            _myAuthService = myAuthService;
        }
        [HttpPut("update/{Id}")]
        public override async Task<ActionResult> Obradi([FromBody] KupacUrediRequest request, CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!korisnickiNalog.isKupac)
            {

                return Unauthorized("Nije autorizovan");

            }
            Data.Models.Kupac? _odabraniKupac;

            _odabraniKupac = _applicationDbContext.Kupac.FirstOrDefault(x => x.Id == request.Id);
            if (_odabraniKupac == null)
            {
                return BadRequest("Pogresan ID");
            }

            _odabraniKupac.BrojMobitela = request.BrojMobitela;
            _odabraniKupac.Ime = request.Ime;
            _odabraniKupac.Prezime=request.Prezime;
            _odabraniKupac.GradId=request.GradId;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(_odabraniKupac.Id);
        }
    }
}
