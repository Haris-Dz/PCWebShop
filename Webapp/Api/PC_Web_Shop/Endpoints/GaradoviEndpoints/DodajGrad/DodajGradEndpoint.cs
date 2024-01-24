

using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;

using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.GaradoviEndpoints.DodajGrad
{
    [Route("grad")]
    public class DodajGradEndpoint:MyBaseEndpoint<DodajGradRequest,Grad>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DodajGradEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("dodaj")]
        public override async Task<Grad> Obradi(DodajGradRequest request, CancellationToken cancellationToken)
        {
            Data.Models.Grad? noviGrad;
            noviGrad = new Data.Models.Grad();
            _applicationDbContext.Add(noviGrad);

            noviGrad.Naziv = request.Naziv;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return noviGrad;


        }
    }


}
