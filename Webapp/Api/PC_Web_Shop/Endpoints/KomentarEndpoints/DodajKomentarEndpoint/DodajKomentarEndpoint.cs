using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KomentarEndpoints.DodajKomentarEndpoint
{
    [Route("komentar")]
    public class DodajKomentarEndpoint:MyBaseEndpoint<DodajKomentarRequest,NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public DodajKomentarEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
            _myAuthService = myAuthService;
        }

        [HttpPost("dodaj")]
        public override async Task<NoResponse> Obradi([FromBody] DodajKomentarRequest request,
            CancellationToken cancellationToken)
        {
            
            Komentar noviKomentar = new Komentar();
            noviKomentar.KupacId=request.KupacId;
            noviKomentar.Komentari = request.Komentari;
            noviKomentar.ArtikalId= request.ArtikalId;
            _applicationDbContext.Add(noviKomentar);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new NoResponse();
        }
    }
}
