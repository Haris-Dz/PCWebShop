using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.PopustEndpoints.PopustIzmijeni
{
    [Route("popust")]
    public class PopustIzmijeniEndpoint:MyBaseEndpoint<PopustIzmijeniRequest, int>
    {

        ApplicationDbContext _applicationDbContext;

        public PopustIzmijeniEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut("izmijeni")]
        public override async Task<int> Obradi([FromBody] PopustIzmijeniRequest request, CancellationToken cancellationToken)
        {
            Data.Models.Popust? odabranipopust;

            odabranipopust = _applicationDbContext.Popust.FirstOrDefault(x => x.Id == request.Id);
            if (odabranipopust == null)
            {
                throw new Exception("Ne postoji ID");
            }

            odabranipopust.Naziv = request.Naziv;
            odabranipopust.DatumOd = request.DatumOd;
            odabranipopust.DatumDo = request.DatumDo;
            odabranipopust.Procenat = request.Procenat;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return odabranipopust.Id;


        }
    }
}
