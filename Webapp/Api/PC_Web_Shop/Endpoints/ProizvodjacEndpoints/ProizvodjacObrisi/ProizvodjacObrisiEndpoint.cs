
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using System.Security.AccessControl;

namespace PC_Web_Shop.Endpoints.ProizvodjacEndpoints.ProizvodjacObrisi
{
    [Route("Proizvodjac")]
    public class ProizvodjacObrisiEndpoint:MyBaseEndpoint<ProizvodjacObrisiRequest, int>
    {
        ApplicationDbContext _applicationDbContext;

        public ProizvodjacObrisiEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpPut("Obrisi")]
        public override async Task<int> Obradi([FromBody] ProizvodjacObrisiRequest request, CancellationToken cancellationToken)
        {
            Proizvodjac? odabraniproizvodjac;
            odabraniproizvodjac=_applicationDbContext.Proizvodjac.FirstOrDefault(x=>x.Id==request.Id);
            if (odabraniproizvodjac == null)
            {
                throw new Exception("POgresan ID");
            }
            odabraniproizvodjac.IsDeleted = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return odabraniproizvodjac.Id;

        }
    }
}
