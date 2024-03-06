using Microsoft.AspNetCore.Mvc;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;
using PC_Web_Shop.Helper.Services;

namespace PC_Web_Shop.Endpoints.PopustEndpoints.PopustIzmijeni
{
    [Route("popust")]
    public class PopustIzmijeniEndpoint:MyBaseEndpoint<PopustIzmijeniRequest, ActionResult>
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _myAuthService;

        public PopustIzmijeniEndpoint(ApplicationDbContext applicationDbContext, MyAuthService myAuthService)
        {
            _applicationDbContext = applicationDbContext;
            _myAuthService = myAuthService;
        }

        [HttpPut("izmijeni")]
        public override async Task<ActionResult> Obradi([FromBody] PopustIzmijeniRequest request, CancellationToken cancellationToken)
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

            Data.Models.Popust? odabranipopust;

            odabranipopust = _applicationDbContext.Popust.FirstOrDefault(x => x.Id == request.Id);
            if (odabranipopust == null)
            {
                throw new Exception("Ne postoji ID");
            }

            odabranipopust.Naziv = request.Naziv;
            odabranipopust.DatumOd = request.DatumOd;
            odabranipopust.DatumDo = request.DatumDo;
            odabranipopust.Procenat = request.Procenat;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(odabranipopust.Id);


        }
    }
}
