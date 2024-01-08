using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.KategorijaEndpoints.GetAll
{
    [Route("kategorija")]
    public class KategorijaGetAllEndpoint:MyBaseEndpoint<KategorijaGetAllRequest, KategorijaGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public KategorijaGetAllEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }

        [HttpGet("get-all")]
        public override async Task<KategorijaGetAllResponse> Obradi([FromQuery] KategorijaGetAllRequest request,
            CancellationToken cancellationToken)
        {
            var kategorija = await _applicationDbContext.ArtikalKategorija
                .OrderByDescending(x => x.Id)
                .Select(x => new KategorijaGetAllResponseKategorije()
                {
                    Id = x.Id,
                    Naziv = x.NazivKategorije
                }).ToListAsync(cancellationToken: cancellationToken);

            return new KategorijaGetAllResponse
            {
                Kategorije = kategorija
            };

        }

    }
}
