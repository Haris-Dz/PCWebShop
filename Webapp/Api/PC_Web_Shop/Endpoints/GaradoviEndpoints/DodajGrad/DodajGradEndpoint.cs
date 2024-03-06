

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;

using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.GaradoviEndpoints.DodajGrad
{
    [Route("grad")]
    public class DodajGradEndpoint:MyBaseEndpoint<DodajGradRequest,ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public DodajGradEndpoint(ApplicationDbContext applicationDbContext,MyAuthService authService)
        {
            _myAuthService = authService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("dodaj")]
        public override async  Task<ActionResult> Obradi(DodajGradRequest request, CancellationToken cancellationToken)
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

            Data.Models.Grad? noviGrad;
            noviGrad = new Data.Models.Grad();
            _applicationDbContext.Add(noviGrad);

            noviGrad.Naziv = request.Naziv;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(noviGrad);


        }
    }


}
