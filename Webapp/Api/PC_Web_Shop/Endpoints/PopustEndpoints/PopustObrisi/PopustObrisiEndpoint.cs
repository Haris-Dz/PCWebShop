
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;
using System.Threading;

namespace PC_Web_Shop.Endpoints.PopustEndpoints.PopustObrisi
{
    [Route("popust")]
    public class PopustObrisiEndpoint:MyBaseEndpoint<PopustObrisiRequest, ActionResult>
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public PopustObrisiEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
            _myAuthService = myAuthService;
        }

        [HttpPut("obrisi")]

        public override async Task<ActionResult> Obradi([FromBody] PopustObrisiRequest request, CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!(korisnickiNalog.isAdmin || korisnickiNalog.isZaposlenik))
            {

                return Unauthorized("Nije autorizovan");

            }

            Popust? _odabranipopust;

            _odabranipopust=_applicationDbContext.Popust.FirstOrDefault(x=>x.Id == request.id);
            if (_odabranipopust == null)
            {
                throw new Exception("Pogresan ID");
            }
            _odabranipopust.IsDeleted = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

          
            return Ok(_odabranipopust.Id);
        }
  

     
       
    }
}
