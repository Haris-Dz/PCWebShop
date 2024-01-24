using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Web_Shop.Data;
using PC_Web_Shop.Helper;

namespace PC_Web_Shop.Endpoints.GaradoviEndpoints.GetAll
{
    [Route("grad")]
    public class GradGetAllEndpoint : MyBaseEndpoint<GradGetAllRequest, GradGetAllResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GradGetAllEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("get-all")]

        public override async Task<GradGetAllResponse> Obradi([FromQuery] GradGetAllRequest request,
            CancellationToken cancellationToken)
        {
            var grad = await _applicationDbContext.Grad
                .OrderByDescending(x => x.Id).Where(x=>x.IsDeleted==false)
                .Select(x => new GradGetAllResponseGradovi()
                {
                    Id = x.Id,
                    Naziv = x.Naziv
                }).ToListAsync(cancellationToken: cancellationToken);

            return new GradGetAllResponse
            {
                Gradovi= grad
            };
        }
    }
}
