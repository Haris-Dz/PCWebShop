using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.Registracija
{
    [Route("registracija")]
    public class RegistracijaEndpoint:MyBaseEndpoint<RegistracijaRequest,Kupac>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RegistracijaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("nova")]

        public override async Task<Kupac> Obradi(RegistracijaRequest request, CancellationToken cancellationToken)
        {
            var kupac = new Kupac
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                Email = request.Email,
                GradId = request.GradId,
                BrojMobitela = request.BrojMobitela,
                KorisnickoIme = request.KorisnickoIme,
                SlikaKorisnika = "",
                isKupac = true,
                Lozinka= request.Lozinka.HashirajSHA256(),
            };
            _applicationDbContext.Add(kupac);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Slika_base64_format))
            {
                byte[]? slika_bajtovi = request.Slika_base64_format?.ParsirajBase64();
                if (slika_bajtovi == null)
                    throw new Exception("pogresan base64 format");
                byte[]? slika_bajtovi_resized = Class.ResizeSlike(slika_bajtovi, 550);
                if (slika_bajtovi_resized == null)
                    throw new Exception ("pogresan format slike");


                string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
                await System.IO.File.WriteAllBytesAsync($"{rootpath}/slike-kupca/{kupac.Id}-slike-kupca.jpg", slika_bajtovi_resized, cancellationToken);
            }
            kupac.SlikaKorisnika =Config.AplikacijURL+ "/slike-kupca/" + kupac.Id.ToString() + "-slike-kupca.jpg";
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return kupac;

        }
    }
}
