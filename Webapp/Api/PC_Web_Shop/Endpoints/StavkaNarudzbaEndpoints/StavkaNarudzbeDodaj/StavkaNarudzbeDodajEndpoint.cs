using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.StavkaNarudzbaEndpoints.StavkaNarudzbeDodaj
{
    [Route("stavka-narudzbe")]
    public class StavkaNarudzbeDodajEndpoint:MyBaseEndpoint<StavkaNarudzbeDodajRequest,IActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public StavkaNarudzbeDodajEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost("dodaj-stavku")]
        public override async Task<IActionResult> Obradi(StavkaNarudzbeDodajRequest request,
            CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!(korisnickiNalog.isKupac))
            {

                return Unauthorized("Nije autorizovan");

            }
            var narudzba = await _applicationDbContext.Narudzba
                .SingleOrDefaultAsync(x => x.Id == request.NarudzbaId);
            var stavkaNarudzbe = await _applicationDbContext.StavkaNarudzbe
                .SingleOrDefaultAsync(x=>x.ArtikalId == request.ArtikalId && x.NarudzbaId == request.NarudzbaId);
            if (stavkaNarudzbe == null)
            {
                var novaStavka = new Data.Models.StavkaNarudzbe()
                {
                    ArtikalId = request.ArtikalId,
                    NarudzbaId = request.NarudzbaId,
                    Kolicina = request.Kolicina,
                    Cijena = request.Cijena * request.Kolicina,
                };
                _applicationDbContext.Add(novaStavka);
                _applicationDbContext.SaveChanges();

                narudzba.UkupnaCijena += novaStavka.Cijena;
                narudzba.UkupnoStavki += 1;
                _applicationDbContext.SaveChanges();
                return Ok();
            }
            else
            {
                narudzba.UkupnaCijena += request.Cijena;
                stavkaNarudzbe.Cijena += request.Cijena;
                stavkaNarudzbe.Kolicina += 1;
                _applicationDbContext.SaveChanges();
                return Ok();
            }
            
        }
    }
}
