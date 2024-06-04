using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Endpoints.ArtikalEndpoints.GetByKategorija;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.GetByPopust
{
    [Route("artikal")]
    public class GetByPopustEndpoint:MyBaseEndpoint<int, GetByPopustResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetByPopustEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-popust")]
        public override async Task<GetByPopustResponse> Obradi(int id, CancellationToken cancellationToken)
        {
            var artikal = await _applicationDbContext.Artikal.Where(x => x.PopustId == id && !x.IsDeleted)
                .OrderByDescending(x => x.Id)
                .Select(x => new GetByPopustResponsePopusti
                {
                    Id = x.Id,
                    Naziv = x.Naziv,
                    Cijena = Math.Round((x.Cijena)*(1-x.Popust.Procenat/100),3),
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

            return new GetByPopustResponse
            {
                Artikal = artikal
            };
        }

    }
  
}
