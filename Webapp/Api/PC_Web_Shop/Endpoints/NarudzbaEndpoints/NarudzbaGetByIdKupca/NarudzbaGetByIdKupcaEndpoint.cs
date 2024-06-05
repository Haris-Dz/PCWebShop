using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Endpoints.NarudzbaEndpoints.NarudzbaGetById;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.NarudzbaEndpoints.NarudzbaGetByIdKupca
{
    [Route("narudzba")]
    public class NarudzbaGetByIdKupcaEndpoint:MyBaseEndpoint<int,IActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public NarudzbaGetByIdKupcaEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("get-by-idKupca/{Id}")]
        public override async Task<IActionResult> Obradi(int Id,
           CancellationToken cancellationToken)

        {
            var narudzbe = await _applicationDbContext.Narudzba.Where(x => x.KupacId == Id && x.UkupnoStavki>0 && x.Zavrsena)
                .OrderByDescending(x => x.Id)
                .Select(x => new NarudzbaGetByIdKupcaResponseNarudzbe()
                {
                    Id = x.Id,
                    UkupnaCijena = x.UkupnaCijena,
                    UkupnoStavki = x.UkupnoStavki,
                    DatumKupovine = (DateTime)x.DatumNarudzbe,
                    StavkaNarudzbe = _applicationDbContext.StavkaNarudzbe.Where(n => n.NarudzbaId == x.Id)
                            .Select(n => new StavkaNarudzbe()
                            {
                                Id = n.Id,
                                Cijena = n.Cijena,
                                Kolicina = n.Kolicina,
                                ArtikalId = n.ArtikalId,
                                Artikal = n.Artikal,
                                NarudzbaId = n.NarudzbaId
                            }).ToList()

                }).ToListAsync(cancellationToken:cancellationToken);
            if (narudzbe == null)
            {
                return BadRequest("Ne postoje");
            }
            double total = 0;
            for (int i = 0; i < narudzbe.Count(); i++)
            {
                total += narudzbe[i].UkupnaCijena;
            }
            return Ok(new NarudzbaGetByIdKupcaResponse
            {
                UkupnoPlaceno = total,
                Narudzbe =narudzbe,
               
             
            });
          
        }
    }
}
