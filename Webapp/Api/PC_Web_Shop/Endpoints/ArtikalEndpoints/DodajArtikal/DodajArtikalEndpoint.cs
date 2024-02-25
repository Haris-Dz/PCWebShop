using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using SkiaSharp;

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
                byte[]? slika_bajtovi_resized = resizeSlike(slika_bajtovi, 550);
                if (slika_bajtovi_resized == null)
                    throw new Exception("pogresan format slike");


                string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
                await System.IO.File.WriteAllBytesAsync($"{rootpath}/slike-artikala/{noviArtikal.Id}-slika-artikla.jpg", slika_bajtovi_resized, cancellationToken);
            }

            noviArtikal.SlikaArtikla = "http://localhost:5174/slike-artikala/" + noviArtikal.Id.ToString() + "-slika-artikla.jpg";
            await _applicationDbContext.SaveChangesAsync(cancellationToken);


            return noviArtikal;

        }
        public static byte[]? resizeSlike(byte[] slikaBajtovi, int size, int quality = 100)
        {
            using var input = new MemoryStream(slikaBajtovi);
            using var inputStream = new SKManagedStream(input);
            using var original = SKBitmap.Decode(inputStream);
            int width, height;
            if (original.Width > original.Height)
            {
                width = size;
                height = original.Height * size / original.Width;
            }
            else
            {
                width = original.Width * size / original.Height;
                height = size;
            }

            using var resized = original
                .Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3);
            if (resized == null) return null;

            using var image = SKImage.FromBitmap(resized);
            return image.Encode(SKEncodedImageFormat.Jpeg, quality)
                .ToArray();
        }
    }
}
