
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.PopustEndpoints.PopustGetAll
{
    [Route("popust")]
    public class PopustGetAllEndpoint:MyBaseEndpoint<PopustGetAllRequest,PopustGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PopustGetAllEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("get-all")]

        public override async Task<PopustGetAllResponse> Obradi([FromQuery] PopustGetAllRequest request, CancellationToken cancellationToken) {

            var popust = await _applicationDbContext.Popust.Where(x => x.IsDeleted == false)
                .Select(x=> new PopustGetAllResponsePopust
                {
                Id=x.Id,
                Naziv=x.Naziv,
                DatumOd=x.DatumOd,
                DatumDo=x.DatumDo,
                Procenat=x.Procenat,
                IsDeleted=x.IsDeleted
                }
                ).ToListAsync(cancellationToken);
            return new PopustGetAllResponse
            {
                Popusti = popust
            };
        }
    }
}
