using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.Login
{
    [Route("registracija")]
    public class LoginEndpoint : MyBaseEndpoint<LoginRequest, ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public LoginEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost("login")]
        public override async Task<ActionResult> Obradi([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var tempHash = request.Lozinka.HashirajSHA256();

            var korisnik = await _applicationDbContext.KorisnickiNalog.FirstOrDefaultAsync(x =>
            x.KorisnickoIme == request.KorisnickoIme
            && x.Lozinka == tempHash, cancellationToken);

            if (korisnik == null)
            {
                return Ok(new MyAuthInfo(null));    
            }

            string randomString = TokenGenerator.Generate(10);
            var noviToken = new AutentifikacijaToken()
            {
                VrijednostTokena = randomString,
                KorisnickiNalog = korisnik,
                VrijemeEvidentiranja = DateTime.Now,
            };
            _applicationDbContext.Add(noviToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(new MyAuthInfo(noviToken)) ;

        }

    }
}
