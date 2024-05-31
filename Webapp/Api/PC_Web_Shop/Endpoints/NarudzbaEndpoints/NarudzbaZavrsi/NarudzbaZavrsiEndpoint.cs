using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.NarudzbaEndpoints.NarudzbaZavrsi
{
    [Microsoft.AspNetCore.Components.Route("narudzba")]
    public class NarudzbaZavrsiEndpoint:MyBaseEndpoint<int,IActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public NarudzbaZavrsiEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPut("narudzba-zavrsi/{Id}")]
        public override async Task<IActionResult> Obradi([FromRoute] int Id,
            CancellationToken cancellationToken)
        {

            var narudzba = _applicationDbContext.Narudzba.Find(Id);
            narudzba.Zavrsena = true;
            _applicationDbContext.SaveChanges();
            return Ok(new NarudzbaZavrsiResponse()
            {
                Id = narudzba.Id,
                UkupnaCijena = narudzba.UkupnaCijena,
                UkupnoStavki = narudzba.UkupnoStavki,
                StavkaNarudzbe = await _applicationDbContext.StavkaNarudzbe.Where(x => x.NarudzbaId == narudzba.Id)
                    .Select(x => new StavkaNarudzbe()
                    {
                        Id = x.Id,
                        Cijena = x.Cijena,
                        Kolicina = x.Kolicina,
                        ArtikalId = x.ArtikalId,
                        Artikal = x.Artikal,
                        NarudzbaId = x.NarudzbaId
                    }).ToListAsync()

            });
        }
    }
}
