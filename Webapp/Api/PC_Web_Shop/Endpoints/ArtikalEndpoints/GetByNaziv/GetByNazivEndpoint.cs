using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;


namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.GetByNaziv
{
    [Route("artikal")]
    public class GetByNazivEndpoint: MyBaseEndpoint<GetByNazivRequest, GetByNazivResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetByNazivEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-naziv")]
        public override async Task<GetByNazivResponse> Obradi([FromQuery]GetByNazivRequest request, CancellationToken cancellationToken)
        {
            var artikal = await _applicationDbContext.Artikal.Where(x =>
            request.Naziv == null ||
            (x.Naziv).StartsWith(request.Naziv)
            ).OrderByDescending(x => x.Naziv)
            .Select(x => new GetByNazivResponseArtikal()
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

            return new GetByNazivResponse
            {
                Artikal = artikal
            };
        }
    }
}
