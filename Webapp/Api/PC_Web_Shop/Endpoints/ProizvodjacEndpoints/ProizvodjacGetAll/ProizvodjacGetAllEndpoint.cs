
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.ProizvodjacEndpoints.ProizvodjacGetAll
{
    [Route("proizvodjac")]
    public class ProizvodjacGetAllEndpoint : MyBaseEndpoint<ProizvodjacGetAllRequest, ProizvodjacGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProizvodjacGetAllEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-all")]
        public override async Task<ProizvodjacGetAllResponse> Obradi([FromQuery] ProizvodjacGetAllRequest request, CancellationToken cancellationToken)
        {
            var proizvodjac = await _applicationDbContext.Proizvodjac.
                OrderByDescending(x => x.Id).Where(x => x.IsDeleted == false).
                Select(x => new ProizvodjacGetAllResponseProizvodjac
                {
                    Id = x.Id,
                    Naziv = x.Naziv
                }).ToListAsync(cancellationToken: cancellationToken);

            return new ProizvodjacGetAllResponse
            {
                Proizvodjaci = proizvodjac
            };
        }
    }
}