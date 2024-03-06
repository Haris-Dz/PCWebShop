using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper.Services;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.Logout
{
    [Route("registracija") ]
    public class LogoutEndpoint : MyBaseEndpoint<NoRequest, ActionResult>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public LogoutEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpPost ("logout")]
        public override async Task<ActionResult> Obradi([FromBody] NoRequest request, CancellationToken cancellationToken)
        {
            AutentifikacijaToken? autentifikacijaToken = _myAuthService.GetAuthInfo().AutentifikacijaToken;
            if (autentifikacijaToken == null)
            {
                return BadRequest("Pogresna operacija");
            }
            _applicationDbContext.Remove(autentifikacijaToken);
            await _applicationDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
