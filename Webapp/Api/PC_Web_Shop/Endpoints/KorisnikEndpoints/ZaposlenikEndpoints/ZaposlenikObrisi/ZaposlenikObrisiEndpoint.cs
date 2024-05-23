using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.ZaposlenikObrisi
{
    [Route("Zaposlenici")]
    public class ZaposlenikObrisiEndpoint: MyBaseEndpoint<int,ActionResult>
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public ZaposlenikObrisiEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _myAuthService = authService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPut("obrisi/{Id}")]
        public override async Task<ActionResult> Obradi(int Id, CancellationToken cancellationToken)
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

            var _odabraniZaposlenik = _applicationDbContext.Zaposlenik.Find(Id);
            if (_odabraniZaposlenik == null)
            {
                return BadRequest("Pogresan ID");
            }
            _odabraniZaposlenik.isDeleted = true;


            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Ok(_odabraniZaposlenik.Id);
        }
    }
}
