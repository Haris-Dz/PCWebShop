
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;

using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.GaradoviEndpoints.GradObrisi
{
    [Route("grad")]
    public class GradObrisiEndpoint:MyBaseEndpoint<GradObrisiRequest,int>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GradObrisiEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut("obrisi")]
        public override async Task<int> Obradi([FromBody] GradObrisiRequest request, CancellationToken cancellationToken)
        {
            Grad? _odabraniGrad;

            _odabraniGrad = _applicationDbContext.Grad.FirstOrDefault(x => x.Id == request.Id);
            if (_odabraniGrad == null)
            {
                throw new Exception("Pogresan ID");
            }
            _odabraniGrad.IsDeleted = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _odabraniGrad.Id;
        }
    }
}
