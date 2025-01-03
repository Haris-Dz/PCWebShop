﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.NarudzbaEndpoints.NarudzbaGetById
{
    [Route("narudzba")]
    public class NarudzbaGetByIdEndpoint : MyBaseEndpoint<int, IActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public NarudzbaGetByIdEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("narudzba-get-by-id/{Id}")]
        public override async Task<IActionResult> Obradi(int Id,
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
            var narudzba = await _applicationDbContext.Narudzba.FindAsync(Id);
            return Ok(new NarudzbaGetByIdResponse()
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
