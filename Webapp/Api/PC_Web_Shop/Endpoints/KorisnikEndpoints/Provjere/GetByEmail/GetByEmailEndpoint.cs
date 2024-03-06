using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Endpoints.KorisnikEndpoints.Provjere.GetByKorisnickoIme;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.Provjere.GetByEmail
{
    [Route("registracija")]
    public class GetByEmailEndpoint: MyBaseEndpoint<GetByEmailRequest, GetByEmailResponse>
    {
    
        private readonly ApplicationDbContext _applicationDbContext;
        public GetByEmailEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-email")]
        public override async Task<GetByEmailResponse> Obradi([FromQuery] GetByEmailRequest request, CancellationToken cancellationToken)
        {

            var korisnik = await _applicationDbContext.Kupac.Where(x => x.Email == request.Email)
                .Select(x => new GetByEmailResponse
                {
                    Email = request.Email,
                }).FirstOrDefaultAsync();
            if (korisnik == null)
            {
                var novi = new GetByEmailResponse
                {
                    Email = "@"
                };
                return novi;
            }

            return korisnik;
        }
    }
}
