using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.LikeArtikal
{
    [Route("artikal")]
    public class LikeArtikalEndpoint : MyBaseEndpoint<int, NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public LikeArtikalEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPut("like/{Id}")]
        public override async Task<NoResponse> Obradi([FromRoute] int Id, CancellationToken cancellationToken)
        {
            var artikal = _applicationDbContext.Artikal.Find(Id);
            artikal.LikeCount += 1;
            _applicationDbContext.SaveChanges();
            return new NoResponse();
        }
    }
}
