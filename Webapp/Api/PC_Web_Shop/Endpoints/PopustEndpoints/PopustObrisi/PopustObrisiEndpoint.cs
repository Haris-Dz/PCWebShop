
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using System.Threading;

namespace PC_Web_Shop.Endpoints.PopustEndpoints.PopustObrisi
{
    [Route("popust")]
    public class PopustObrisiEndpoint:MyBaseEndpoint<PopustObrisiRequest, int>
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public PopustObrisiEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut("obrisi")]

        public override async Task<int> Obradi([FromBody] PopustObrisiRequest request, CancellationToken cancellationToken)
        {
            Popust? _odabranipopust;

            _odabranipopust=_applicationDbContext.Popust.FirstOrDefault(x=>x.Id == request.id);
            if (_odabranipopust == null)
            {
                throw new Exception("Pogresan ID");
            }
            _odabranipopust.IsDeleted = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _odabranipopust.Id;
        }
  

     
       
    }
}
