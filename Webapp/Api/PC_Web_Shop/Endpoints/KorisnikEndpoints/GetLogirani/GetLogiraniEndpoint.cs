
using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.KorisnikEndpoints.GetLogirani
{
    [Route("registracija")]
    public class GetLogiraniEndpoint: MyBaseEndpoint<NoRequest, MyAuthInfo>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;
        public GetLogiraniEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _myAuthService = myAuthService;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<MyAuthInfo> Obradi([FromBody] NoRequest request, CancellationToken cancellationToken)
        {
            AutentifikacijaToken? autentifikacijaToken = _myAuthService.GetAuthInfo().AutentifikacijaToken;

            return new MyAuthInfo(autentifikacijaToken);
        }
    }
}
