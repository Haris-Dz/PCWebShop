using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.DodajArtikal
{
    [Route("artikal")]
    public class DodajArtikalEndpoint:MyBaseEndpoint<DodajArtikalRequest,Artikal>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DodajArtikalEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("dodaj")]
        public override async Task<Artikal> Obradi(DodajArtikalRequest request,CancellationToken cancellationToken)
        {
            Data.Models.Artikal? noviArtikal;
            noviArtikal = new Data.Models.Artikal();
            _applicationDbContext.Add(noviArtikal);

            noviArtikal.SlikaArtikla = Config.SlikeURL + "praznoo.png";
            noviArtikal.Naziv = request.Naziv;
            noviArtikal.Cijena = request.Cijena;
            noviArtikal.Opis = request.Opis;
            noviArtikal.KratkiOpis = request.KratkiOpis;
            noviArtikal.StanjeNaSkladistu = request.StanjeNaSkladistu;
            noviArtikal.Sifra = request.Sifra;
            noviArtikal.Model = request.Model;
            noviArtikal.ArtikalKategorijaId = request.ArtikalKategorijaId;
            noviArtikal.PopustId = request.PopustId;
            noviArtikal.SkladisteId = request.SkladisteId;
            noviArtikal.ProizvodjacId = request.ProizvodjacId;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            
            return noviArtikal;

        }
    }
}
