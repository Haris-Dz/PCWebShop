using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.ZaposlenikEndpoints.ZaposlenikDodajEndpoint
{
    [Route("Zaposlenici")]
    public class ZaposlenikDodajEndpoint:MyBaseEndpoint<ZaposlenikDodajRequest,ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public ZaposlenikDodajEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _myAuthService = authService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost("dodaj")]
        public override async Task<ActionResult> Obradi(ZaposlenikDodajRequest request, CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!korisnickiNalog.isAdmin)
            {

                return Unauthorized("Nije autorizovan");

            }
            var provjera = await _applicationDbContext.KorisnickiNalog.FirstOrDefaultAsync(x =>x.KorisnickoIme==request.KorisnickoIme, cancellationToken);
            if (provjera != null)
            {
                return BadRequest("Korisnicko ime vec postoji");
            }
            provjera = await _applicationDbContext.Zaposlenik.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            if (provjera != null)
            {
                return BadRequest("Email vec postoji");
            }
            string temppw=TokenGenerator.Generate(9);
            var zaposlenik = new Zaposlenik
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                KorisnickoIme = request.KorisnickoIme,
                SlikaKorisnika = "",
                Email = request.Email,
                BrojMobitela = request.BrojMobitela,
                Ulica = request.Ulica,
                GradId = request.GradId,
                Lozinka = temppw.HashirajSHA256(),
                isZaposlenik = true
                
            };
            _applicationDbContext.Add(zaposlenik);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Slika_base64_format))
            {
                byte[]? slika_bajtovi = request.Slika_base64_format?.ParsirajBase64();
                if (slika_bajtovi == null)
                    return BadRequest("pogresan base64 format");
                byte[]? slika_bajtovi_resized = Class.ResizeSlike(slika_bajtovi, 550);
                if (slika_bajtovi_resized == null)
                    return BadRequest("pogresan format slike");


                string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
                await System.IO.File.WriteAllBytesAsync($"{rootpath}/slike-zaposlenika/{zaposlenik.Id}-slika-zaposlenika.jpg", slika_bajtovi_resized, cancellationToken);
            }
            zaposlenik.SlikaKorisnika = "http://localhost:5174/slike-zaposlenika/" + zaposlenik.Id.ToString() + "-slika-zaposlenika.jpg";
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Ok();
        }
    }
}
