using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;



namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.UpdateArtikal
{
    [Route("artikal")]
    public class ObrisiArtikalEndpoint:MyBaseEndpoint<UpdateArtikalRequest, ActionResult >
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public ObrisiArtikalEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut("update/{Id}")]
        public override async Task<ActionResult> Obradi([FromBody] UpdateArtikalRequest request, CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!(korisnickiNalog.isAdmin || korisnickiNalog.isZaposlenik))
            {

                return Unauthorized("Nije autorizovan");

            }
            Data.Models.Artikal? _odabraniArtikal;

            _odabraniArtikal = _applicationDbContext.Artikal.FirstOrDefault(x => x.Id == request.Id);
            if (_odabraniArtikal == null)
            {
                return BadRequest("Pogresan ID");
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

            return Ok(_odabraniArtikal.Id);
        }


    }
}
