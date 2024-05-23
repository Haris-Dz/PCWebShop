using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Endpoints.ArtikalEndpoints.GetByNaziv;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.GetByNaziv
{
    [Route("Zaposlenici")]
    public class GetByNazivZaposlenikEndpoint : MyBaseEndpoint<GetByNazivZaposlenikRequest, ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public GetByNazivZaposlenikEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _myAuthService = authService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-naziv")]
        public override async Task<ActionResult> Obradi([FromQuery] GetByNazivZaposlenikRequest request, CancellationToken cancellationToken)
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

            var zaposlenik = await _applicationDbContext.Zaposlenik.Where(x =>
            (request.Naziv == null ||
            (x.KorisnickoIme).StartsWith(request.Naziv)) && (x.isDeleted != true)
            ).OrderBy(x => x.Id)
            .Select(x => new ZaposlenikGetByNazivResponseZaposlenici()
            {
                Id = x.Id,
                KorisnickoIme = x.KorisnickoIme,
                SlikaKorisnika = x.SlikaKorisnika,
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojMobitela = x.BrojMobitela,
                Ulica = x.Ulica,
                Email = x.Email,
                Grad = x.Grad

            })
            .ToListAsync(cancellationToken: cancellationToken);

            return Ok(new GetByNazivZaposlenikResponse
            {
                Zaposlenik = zaposlenik
            });
        }
    }
}
