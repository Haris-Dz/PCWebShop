
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.KupacEndpoints.KupacGetAll
{
    [Route ("kupac")]
    public class KupacGetAllEndpoint:MyBaseEndpoint<NoRequest,KupacGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public KupacGetAllEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("kupac-get-all")]
        public override async Task<KupacGetAllResponse> Obradi([FromQuery]NoRequest noRequest,CancellationToken cancellationToken)
        {
            var kupci = await _applicationDbContext.Kupac.OrderByDescending(x => x.Id)
                .Select(x=>new KupacGetAllResponseKupci()
                {
                    Id = x.Id,
                    BrojMobitela = x.BrojMobitela,
                    Email = x.Email,
                    GradId = x.GradId,
                    Ime = x.Ime,
                    KorisnickoIme   = x.KorisnickoIme,
                    Prezime = x.Prezime,
                    SlikaKorisnika=x.SlikaKorisnika
                }).ToListAsync(cancellationToken:cancellationToken);

            return new KupacGetAllResponse { 
            Kupci = kupci,
            };
        }
    }
}
