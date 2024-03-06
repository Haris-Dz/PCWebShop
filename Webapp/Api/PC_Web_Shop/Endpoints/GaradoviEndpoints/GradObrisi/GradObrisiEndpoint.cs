
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;

using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.GaradoviEndpoints.GradObrisi
{
    [Route("grad")]
    public class GradObrisiEndpoint:MyBaseEndpoint<GradObrisiRequest,ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public GradObrisiEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
            _myAuthService= myAuthService;
        }

        [HttpPut("obrisi")]
        public override async Task<ActionResult> Obradi([FromBody] GradObrisiRequest request, CancellationToken cancellationToken)
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

            Grad? _odabraniGrad;

            _odabraniGrad = _applicationDbContext.Grad.FirstOrDefault(x => x.Id == request.Id);
            if (_odabraniGrad == null)
            {
                throw new Exception("Pogresan ID");
            }
            _odabraniGrad.IsDeleted = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(_odabraniGrad.Id);
        }
    }
}
