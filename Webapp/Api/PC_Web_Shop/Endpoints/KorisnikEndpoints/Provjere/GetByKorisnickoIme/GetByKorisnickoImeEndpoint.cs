using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.Provjere.GetByKorisnickoIme
{
    [Route("registracija")]
    public class GetByKorisnickoImeEndpoint:MyBaseEndpoint<GetByKorisnickoImeRequest, GetByKorisnickoImeResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetByKorisnickoImeEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-username")]
        public override async Task<GetByKorisnickoImeResponse> Obradi([FromQuery] GetByKorisnickoImeRequest request, CancellationToken cancellationToken)
        {
            
            var korisnik = await _applicationDbContext.KorisnickiNalog.Where(x => x.KorisnickoIme == request.Username)
                .Select(x => new GetByKorisnickoImeResponse
                {
                    KNalog = request.Username,
                }).FirstOrDefaultAsync();
            if (korisnik == null)
            {
                var noviKorisnik = new GetByKorisnickoImeResponse { KNalog = "" };
                return noviKorisnik;
            }

            return korisnik;
        }
    }
}
