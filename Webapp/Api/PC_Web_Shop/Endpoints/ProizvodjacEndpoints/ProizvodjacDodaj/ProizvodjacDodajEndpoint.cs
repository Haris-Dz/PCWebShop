
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.ProizvodjacEndpoints.ProizvodjacDodaj
{
    [Route("proizvodjac")]
    public class ProizvodjacDodajEndpoint:MyBaseEndpoint<ProizvodjacDodajRequest, Proizvodjac>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProizvodjacDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost("dodaj")]
        public override async Task<Proizvodjac>Obradi(ProizvodjacDodajRequest request, CancellationToken cancellationToken)
        {
            Proizvodjac? noviproizvodjac;
            noviproizvodjac= new Proizvodjac();
            _applicationDbContext.Add(noviproizvodjac);

            noviproizvodjac.Naziv = request.Naziv;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return noviproizvodjac;
        }
           
          

    }
}
