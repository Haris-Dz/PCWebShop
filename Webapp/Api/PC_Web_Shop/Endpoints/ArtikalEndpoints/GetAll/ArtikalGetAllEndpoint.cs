using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.GetAll
{
    [Route("artikal")]
    public class ArtikalGetAllEndpoint : MyBaseEndpoint<ArtikalGetAllRequest,ArtikalGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ArtikalGetAllEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("get-all")]
        public override async Task<ArtikalGetAllResponse> Obradi([FromQuery] ArtikalGetAllRequest request,
            CancellationToken cancellationToken)
        {
            var artikal = await _applicationDbContext.Artikal.Where(x=>!x.IsDeleted)
                
                .OrderByDescending(x => x.Id)
                .Select(x => new ArtikalGetAllResponseArtikal()
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Opis = x.Opis,
                    KratkiOpis = x.KratkiOpis,
                    Model = x.Model,
                    Sifra = x.Sifra,
                    StanjeNaSkladistu = x.StanjeNaSkladistu,
                    Popust = x.Popust,
                    Proizvodjac = x.Prozivodjac,
                    ArtikalKategorija = x.ArtikalKategorija,
                    SlikaArtikla = x.SlikaArtikla
                    
                })
                .ToListAsync(cancellationToken: cancellationToken);

            return new ArtikalGetAllResponse
            {
                Artikal = artikal
            };

        }
    }
}
