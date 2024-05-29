using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KomentarEndpoints.GetKomentariEndpoint
{
    [Microsoft.AspNetCore.Components.Route("komentar")]
    public class GetKomentariEndpoint:MyBaseEndpoint<int,GetKomentariResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetKomentariEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("get-komentari/{Id}")]
        public override async Task<GetKomentariResponse> Obradi([FromRoute] int Id, CancellationToken cancellationToken)
        {
            var komentari = await _applicationDbContext.Komentar.Where(x => x.ArtikalId == Id)
                .OrderByDescending(x => x.Id)
                .Select(k => new KomentariGetKomentariResponse()
                {
                    Komentari = k.Komentari,
                    korisnickoIme = k.Kupac.KorisnickoIme,
                    
                }).ToListAsync(cancellationToken: cancellationToken);
            
            return new GetKomentariResponse
            {
                Komentari = komentari
            };
        }
    }
}
