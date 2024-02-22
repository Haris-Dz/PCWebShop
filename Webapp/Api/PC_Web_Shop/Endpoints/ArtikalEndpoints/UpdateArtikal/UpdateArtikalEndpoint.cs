using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;



namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.UpdateArtikal
{
    [Route("artikal")]
    public class ObrisiArtikalEndpoint:MyBaseEndpoint<UpdateArtikalRequest, int >
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ObrisiArtikalEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut("update/{Id}")]
        public override async Task<int> Obradi([FromBody] UpdateArtikalRequest request, CancellationToken cancellationToken)
        {
            Data.Models.Artikal? _odabraniArtikal;

            _odabraniArtikal = _applicationDbContext.Artikal.FirstOrDefault(x => x.Id == request.Id);
            if (_odabraniArtikal == null)
            {
                throw new Exception("Pogresan ID");
            }
            _odabraniArtikal.Naziv = request.Naziv;
            _odabraniArtikal.Cijena = request.Cijena;
            _odabraniArtikal.Opis = request.Opis;
            _odabraniArtikal.KratkiOpis = request.KratkiOpis;
            _odabraniArtikal.StanjeNaSkladistu = request.StanjeNaSkladistu;
            _odabraniArtikal.Sifra = request.Sifra;
            _odabraniArtikal.Model = request.Model;
            _odabraniArtikal.PopustId = request.PopustId;
            _odabraniArtikal.ArtikalKategorijaId = request.ArtikalKategorijaId;
            _odabraniArtikal.ProizvodjacId=request.ProizvodjacId;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _odabraniArtikal.Id;
        }


    }
}
