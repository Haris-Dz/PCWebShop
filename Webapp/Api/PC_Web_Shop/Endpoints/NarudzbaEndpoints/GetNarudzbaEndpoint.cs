using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.NarudzbaEndpoints
{
    [Route("narudzba")]
    public class GetNarudzbaEndpoint:MyBaseEndpoint<GetNarudzbaRequest,IActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public GetNarudzbaEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("get-narudzba")]
        public override async Task<IActionResult> Obradi(GetNarudzbaRequest request,
            CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!(korisnickiNalog.isKupac))
            {

                return Ok();

            }
            var narudzba = await _applicationDbContext.Narudzba
                .SingleOrDefaultAsync(x => x.KupacId == request.KupacId && x.Zavrsena == false);
            if (narudzba == null)
            {
                var novanarudzba = new Narudzba()
                {
                    UkupnaCijena = 0,
                    Zavrsena = false,
                    UkupnoStavki = 0,
                    KupacId = request.KupacId
                };
                _applicationDbContext.Add(novanarudzba);
                _applicationDbContext.SaveChanges();
                return Ok( new GetNarudzbaResponse()
                {
                    Id = novanarudzba.Id,
                    UkupnaCijena = novanarudzba.UkupnaCijena,
                    UkupnoStavki = novanarudzba.UkupnoStavki,
                });

            }
            else
            {
                return Ok(new GetNarudzbaResponse()
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
}
