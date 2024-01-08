using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;


namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.GetByKategorija
{
    [Route("artikal")]
    public class GetByKategorijaEndpoint : MyBaseEndpoint<int, GetByKategorijaResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetByKategorijaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-kategorija")]
        public override async Task<GetByKategorijaResponse> Obradi(int id, CancellationToken cancellationToken)
        {
            var artikal = await _applicationDbContext.Artikal.Where(x=>x.ArtikalKategorijaId == id && !x.IsDeleted)
                .OrderByDescending(x => x.Id)
                .Select(x => new GetByKategorijaResponseKategorije
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



                }).ToListAsync(cancellationToken: cancellationToken);

            return new GetByKategorijaResponse
            {
                Artikal = artikal
            };
        }
    }
}