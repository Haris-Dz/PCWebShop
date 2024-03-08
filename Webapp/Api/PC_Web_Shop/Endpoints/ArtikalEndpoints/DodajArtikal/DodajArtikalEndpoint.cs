using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;
using SkiaSharp;

namespace PC_Web_Shop.Endpoints.ArtikalEndpoints.DodajArtikal
{
    [Route("artikal")]
    public class DodajArtikalEndpoint:MyBaseEndpoint<DodajArtikalRequest,ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public DodajArtikalEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
            _myAuthService = myAuthService;
        }

        [HttpPost("dodaj")]
        public override async Task<ActionResult> Obradi(DodajArtikalRequest request,CancellationToken cancellationToken)
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
            Data.Models.Artikal? noviArtikal;
            noviArtikal = new Data.Models.Artikal();
            _applicationDbContext.Add(noviArtikal);

            noviArtikal.SlikaArtikla = "";
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

            if (!string.IsNullOrEmpty(request.Slika_base64_format))
            {
                byte[]? slika_bajtovi= request.Slika_base64_format?.ParsirajBase64();
                if (slika_bajtovi == null)
                    throw new Exception("pogresan base64 format");
                byte[]? slika_bajtovi_resized = Class.ResizeSlike(slika_bajtovi, 550);
                if (slika_bajtovi_resized == null)
                    throw new Exception("pogresan format slike");


                string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
                await System.IO.File.WriteAllBytesAsync($"{rootpath}/slike-artikala/{noviArtikal.Id}-slika-artikla.jpg", slika_bajtovi_resized, cancellationToken);
            }
            noviArtikal.SlikaArtikla = "http://localhost:5174/slike-artikala/" + noviArtikal.Id.ToString() + "-slika-artikla.jpg";
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Ok(noviArtikal);

        }

    }
}
