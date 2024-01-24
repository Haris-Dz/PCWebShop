
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.PopustEndpoints.PopustDodaj
{
    [Route("popust")]

    public class PopustDodajEndpoint:MyBaseEndpoint<PopustDodajRequest, Popust>
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public PopustDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("dodaj")]

        public override async Task<Popust> Obradi(PopustDodajRequest request, CancellationToken cancellationToken)
        {
            Data.Models.Popust? novipopust;
            novipopust = new Data.Models.Popust();
            _applicationDbContext.Add(novipopust);

            novipopust.Naziv=request.Naziv;
            novipopust.DatumDo=request.DatumDo;
            novipopust.DatumOd=request.DatumOd;
            novipopust.Procenat=request.Procenat;
   

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return novipopust;

        }
    }
}
