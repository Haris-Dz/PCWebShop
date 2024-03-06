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

            return kupac;

        }
    }
}
