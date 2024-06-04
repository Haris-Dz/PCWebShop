using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.ZaposlenikGetById
{
    [Route("Zaposlenici")]
    public class ZaposelinikGetByIdEndpoint:MyBaseEndpoint<int, ZaposelinikGetByIdResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ZaposelinikGetByIdEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-id/{Id}")]
        public override async Task<ZaposelinikGetByIdResponse> Obradi([FromRoute]int Id, CancellationToken cancellationToken)
        {
            var zaposlenik = await _applicationDbContext.Zaposlenik
                .Select(x => new ZaposelinikGetByIdResponse
                {
                    Id = x.Id,
                    BrojMobitela = x.BrojMobitela,
                    Email = x.Email,
                    GradId = x.GradId,
                    Ime = x.Ime,
                    Ulica= x.Ulica,
                    KorisnickoIme = x.KorisnickoIme,
                    Prezime = x.Prezime,
                    SlikaKorisnika = x.SlikaKorisnika

                })
                .SingleAsync(x=>x.Id==Id,cancellationToken:cancellationToken);

            return zaposlenik;
        }
    }
}
