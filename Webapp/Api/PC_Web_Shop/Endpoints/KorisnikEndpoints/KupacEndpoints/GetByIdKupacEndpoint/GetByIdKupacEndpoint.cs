
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.KupacEndpoints.GetByIdKupacEndpoint
{
    [Route("kupac")]
    public class GetByIdKupacEndpoint:MyBaseEndpoint<int,GetByIdKupacResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetByIdKupacEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-id")]
        public override async Task<GetByIdKupacResponse> Obradi(int id, CancellationToken cancellationToken)
        {
            var kupac = await _applicationDbContext.Kupac
                .OrderByDescending(x => x.Id)
                .Select(x => new GetByIdKupacResponse
                {
                    Id=x.Id,
                    BrojMobitela = x.BrojMobitela,
                    Email = x.Email,
                    GradId = x.GradId,
                    Ime = x.Ime,
                    KorisnickoIme = x.KorisnickoIme,
                    Prezime = x.Prezime,
                    SlikaKorisnika = x.SlikaKorisnika

                })
                .SingleAsync(x => x.Id == id, cancellationToken: cancellationToken);

            return kupac;
        }
    }
}
