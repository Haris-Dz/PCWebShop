
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Endpoints.ArtikalEndpoints.GetAll;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.GetAllZaposlenici
{
    [Route("Zaposlenici")]
    public class GetAllZapolseniciEndpoint : MyBaseEndpoint<NoRequest, ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public GetAllZapolseniciEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _myAuthService = authService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-all")]
        public override async Task<ActionResult> Obradi([FromQuery]NoRequest request, CancellationToken cancellationToken)
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
            var zaposenik = await _applicationDbContext.Zaposlenik.Where(x => !x.isDeleted)
                .OrderBy(x => x.Id)
                .Select(x => new ZaposlenikGetAllResponseZaposlenici()
                {
                    Id=x.Id,
                    KorisnickoIme=x.KorisnickoIme,
                    SlikaKorisnika=x.SlikaKorisnika,
                    Ime=x.Ime,  
                    Prezime=x.Prezime,
                    BrojMobitela=x.BrojMobitela,
                    Ulica=x.Ulica,
                    Email=x.Email,
                    Grad=x.Grad,
                    GradId=x.GradId,

                })
                .ToListAsync(cancellationToken: cancellationToken);

            return Ok(new GetAllZaposleniciResponse
            {
                Zaposlenik = zaposenik
            });

        }
    }
}
