using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Endpoints.StavkaNarudzbaEndpoints.StavkaNarudzbeDodaj;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.StavkaNarudzbaEndpoints.StavkaNarudzbeUkloni
{
    [Route("stavka-narudzbe")]
    public class StavkaNarudzbeUkloniEndpoint:MyBaseEndpoint<int,NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public StavkaNarudzbeUkloniEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpDelete("ukloni-stavku")]
        public override async Task<NoResponse> Obradi(int request,
            CancellationToken cancellationToken)
        {
            var stavkaNarudzbe = _applicationDbContext.StavkaNarudzbe.FirstOrDefault(x => x.Id == request);
            var narudzba = _applicationDbContext.Narudzba.FirstOrDefault(x => x.Id == stavkaNarudzbe.NarudzbaId);
            var artikal = _applicationDbContext.Artikal.FirstOrDefault(x => x.Id == stavkaNarudzbe.ArtikalId);
            if (stavkaNarudzbe.Kolicina>1)
            {
                stavkaNarudzbe.Cijena -= artikal.Cijena;
                narudzba.UkupnaCijena -= artikal.Cijena;
                stavkaNarudzbe.Kolicina-=1;
                _applicationDbContext.SaveChanges();
                return new NoResponse();

            }
            else
            {
                narudzba.UkupnoStavki -= 1;
                narudzba.UkupnaCijena -= artikal.Cijena;
                _applicationDbContext.Remove(stavkaNarudzbe);
                _applicationDbContext.SaveChanges();
                return new NoResponse();
            }
            
        }
    }
}
