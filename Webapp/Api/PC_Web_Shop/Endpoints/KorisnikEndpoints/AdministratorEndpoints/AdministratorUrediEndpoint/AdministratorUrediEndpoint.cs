using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.AdministratorEndpoints.AdministratorUrediEndpoint
{
    [Route("Administrator")]
    public class AdministratorUrediEndpoint:MyBaseEndpoint<AdministratorUrediRequest, ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public AdministratorUrediEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _myAuthService = authService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPut("uredi")]
        public override async Task<ActionResult> Obradi([FromBody] AdministratorUrediRequest request, CancellationToken cancellationToken)
        {
            if (!_myAuthService.IsLogiran())
            {
                return Unauthorized("Nije logiran");
            }
            var korisnickiNalog = _myAuthService.GetAuthInfo().KorisnickiNalog!;
            if (!korisnickiNalog.isAdmin)
            {

                return Unauthorized("Nije autorizovan");

            }

            var _odabraniadmin = _applicationDbContext.Administrator.Find(request.Id);
            if (_odabraniadmin == null)
            {
                return BadRequest("Pogresan ID");
            }

          _odabraniadmin.Ime=request.Ime;
           _odabraniadmin.Prezime=request.Prezime;
           


            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Ok(_odabraniadmin.Id);
        }
    }
}

