using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.ZaposlenikGetById;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.AdministratorEndpoints.AdministratorGetByid
{
    [Route("Administrator")]
    public class AdministratorGetByIdEndpoint:MyBaseEndpoint<int, AdministratorGetByIdResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AdministratorGetByIdEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-id/{Id}")]
        public override async Task<AdministratorGetByIdResponse> Obradi([FromRoute] int Id, CancellationToken cancellationToken)
        {
            var zaposlenik = await _applicationDbContext.Administrator
                .Select(x => new AdministratorGetByIdResponse
                {
                    Id = x.Id,
                    Email = x.Email,
                    Ime = x.Ime,
                    KorisnickoIme = x.KorisnickoIme,
                    Prezime = x.Prezime,
                    SlikaKorisnika = x.SlikaKorisnika

                })
                .SingleAsync(x => x.Id == Id, cancellationToken: cancellationToken);
               

            return zaposlenik;
        }
    }
}
