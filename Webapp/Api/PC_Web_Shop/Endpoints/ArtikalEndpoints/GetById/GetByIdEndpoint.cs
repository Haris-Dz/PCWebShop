using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;

using PC_Web_Shop.Helper;


namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.GetById
{
    [Route("artikal")]
    public class GetByIdEndpoint: MyBaseEndpoint<int, GetByIdResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GetByIdEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-id")]
        public override async Task<GetByIdResponse> Obradi(int id, CancellationToken cancellationToken)
        {
            var artikal = await _applicationDbContext.Artikal
                .OrderByDescending(x => x.Id)
                .Select(x => new GetByIdResponse
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
                    SlikaArtikla = x.SlikaArtikla,
                    LikeCount = x.LikeCount



                })
                .SingleAsync(x => x.Id == id, cancellationToken: cancellationToken);

            return artikal;
        }
    }
}
