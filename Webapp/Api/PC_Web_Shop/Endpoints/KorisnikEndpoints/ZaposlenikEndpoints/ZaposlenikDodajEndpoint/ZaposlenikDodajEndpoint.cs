﻿using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Macs;
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
        private readonly EmailService _emailService;

        public ZaposlenikDodajEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService, EmailService emailService)
        {
            _myAuthService = authService;
            _applicationDbContext = applicationDbContext;
            _emailService = emailService;
        }
        [HttpPost("dodaj")]
        public override async Task<ActionResult> Obradi(ZaposlenikDodajRequest request, CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Not logged in.");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!korisnickiNalog.isAdmin)
            {

                return Unauthorized("Unauthorized.");

            }
            var provjera = await _applicationDbContext.KorisnickiNalog.FirstOrDefaultAsync(x =>x.KorisnickoIme==request.KorisnickoIme, cancellationToken);
            if (provjera != null)
            {
                return BadRequest("This username is already in use.");
            }
            provjera = await _applicationDbContext.Zaposlenik.FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
            if (provjera != null)
            {
                return BadRequest("This email address is already in use.");
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
                    return BadRequest("wrong base64 format");
                byte[]? slika_bajtovi_resized = Class.ResizeSlike(slika_bajtovi, 550);
                if (slika_bajtovi_resized == null)
                    return BadRequest("wrong picture format");


                string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
                await System.IO.File.WriteAllBytesAsync($"{rootpath}/slike-zaposlenika/{zaposlenik.Id}-slika-zaposlenika.jpg", slika_bajtovi_resized, cancellationToken);
            }
            zaposlenik.SlikaKorisnika =Config.AplikacijURL  + "/slike-zaposlenika/" + zaposlenik.Id.ToString() + "-slika-zaposlenika.jpg";
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            //Email emailModel = new Email();
            //emailModel.To = request.Email;
            //emailModel.Subject = "Registracija";
            
            //emailModel.Body = "Korisnicko ime:"+request.KorisnickoIme+ " Lozinka: " + temppw;
            //await _emailService.SendEmailAsync(emailModel);
            return Ok();
        }
    }
}
