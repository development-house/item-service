using Domain;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application;
public class ItemContext
{
    public ClaimsPrincipal User { get; }
    public ItemContext(IHttpContextAccessor contextAccessor)
    {
        var httpContext = contextAccessor?.HttpContext ?? throw new ArgumentNullException(nameof(contextAccessor));
        User = httpContext.User;
    }

    public Task<string?> GetItem()
    {
        throw new NotImplementedException();
    }
}
