using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;


namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.ObrisiArtikal
{
    [Route("artikal")]
    public class ObrisiArtikalEndpoint:MyBaseEndpoint<ObrisiArtikalRequest, int >
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ObrisiArtikalEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut("obrisi")]
        public override async Task<int> Obradi([FromBody] ObrisiArtikalRequest request, CancellationToken cancellationToken)
        {
            Artikal? _odabraniArtikal;

            _odabraniArtikal = _applicationDbContext.Artikal.FirstOrDefault(x => x.Id == request.Id);
            if (_odabraniArtikal == null)
            {
                throw new Exception("Pogresan ID");
            }
            _odabraniArtikal.IsDeleted=true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _odabraniArtikal.Id;
        }


    }
}
