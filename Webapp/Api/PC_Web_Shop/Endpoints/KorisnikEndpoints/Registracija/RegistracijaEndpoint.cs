using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using Stripe;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.Registracija
{
    [Route("registracija")]
    public class RegistracijaEndpoint:MyBaseEndpoint<RegistracijaRequest,IActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RegistracijaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("nova")]

        public override async Task<IActionResult> Obradi(RegistracijaRequest request, CancellationToken cancellationToken)
        {
            if (_applicationDbContext.KorisnickiNalog.FirstOrDefault(x => x.KorisnickoIme == request.KorisnickoIme) != null)
            {
                return BadRequest("This username is already in use.");
            }
            else if (request.KorisnickoIme == "")
            {
                return BadRequest("Username can not be empty field.");
            }
            else if(_applicationDbContext.Kupac.FirstOrDefault(x=>x.Email==request.Email) != null)
            {
                return BadRequest("This email address is already in use.");
            }
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
                    throw new Exception("wrong base64 format.");
                byte[]? slika_bajtovi_resized = Class.ResizeSlike(slika_bajtovi, 550);
                if (slika_bajtovi_resized == null)
                    throw new Exception ("wrong picture format.");


                string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
                await System.IO.File.WriteAllBytesAsync($"{rootpath}/slike-kupca/{kupac.Id}-slike-kupca.jpg", slika_bajtovi_resized, cancellationToken);
            }
            kupac.SlikaKorisnika =Config.AplikacijURL+ "/slike-kupca/" + kupac.Id.ToString() + "-slike-kupca.jpg";
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(kupac);

        }
    }
}
