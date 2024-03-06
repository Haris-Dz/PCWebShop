using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Data.Models;
using System.Text.Json.Serialization;

namespace PC_Web_Shop.Helper.Services
{
    public class MyAuthService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyAuthService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor) {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public bool IsLogiran()
        {
            return GetAuthInfo().isLogiran;
        }

        public bool IsAdmin()
        {
            return GetAuthInfo().KorisnickiNalog?.isAdmin ?? false;
        }
        public bool IsZaposlenik()
        {
            return GetAuthInfo().KorisnickiNalog?.isZaposlenik ?? false;
        }
        public bool IsKupac()
        {
            return GetAuthInfo().KorisnickiNalog?.isKupac ?? false;
        }



        public MyAuthInfo GetAuthInfo()
        {
            string? authToken = _httpContextAccessor.HttpContext!.Request.Headers["my-auth-token"];

            AutentifikacijaToken? autentifikacijaToken = _applicationDbContext.AutentifikacijaToken
                .Include(x => x.KorisnickiNalog)
                .SingleOrDefault(x => x.VrijednostTokena == authToken);

            return new MyAuthInfo(autentifikacijaToken);
        }
    }

    public class MyAuthInfo
    {
        public MyAuthInfo(AutentifikacijaToken? autentifikacijaToken)
        {
            this.AutentifikacijaToken = autentifikacijaToken;
        }

        [JsonIgnore]
        public KorisnickiNalog? KorisnickiNalog => AutentifikacijaToken?.KorisnickiNalog;
        public AutentifikacijaToken? AutentifikacijaToken { get; set; }

        public bool isLogiran => KorisnickiNalog != null;

    }
}
