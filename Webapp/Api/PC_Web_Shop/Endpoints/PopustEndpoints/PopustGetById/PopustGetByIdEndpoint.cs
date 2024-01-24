
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.PopustEndpoints.PopustGetById
{
    [Route("popust")]
    public class PopustGetByIdEndpoint:MyBaseEndpoint<int, PopustGetByIdResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PopustGetByIdEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("get-byid")]

        public override async Task<PopustGetByIdResponse> Obradi(int id, CancellationToken cancellationToken)
        {
            var popust = await _applicationDbContext.Popust
                .OrderByDescending(x => x.Id)
                .Select(x => new PopustGetByIdResponse
            {
                Id = x.Id,
                Naziv = x.Naziv,
                DatumOd = x.DatumOd,
                DatumDo = x.DatumDo,
                Procenat = x.Procenat,
                IsDeleted = x.IsDeleted
            }).SingleAsync(x => x.Id == id, cancellationToken: cancellationToken);

            return popust;

           
        }
    }


}
