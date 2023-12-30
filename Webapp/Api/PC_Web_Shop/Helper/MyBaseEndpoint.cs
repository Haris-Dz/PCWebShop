using Microsoft.AspNetCore.Mvc;

namespace PC_Web_Shop.Helper;

[ApiController]
public abstract class MyBaseEndpoint<TRequest, TResponse> : ControllerBase
{
    public abstract Task<TResponse> Obradi(TRequest request, CancellationToken cancellationToken);
}
