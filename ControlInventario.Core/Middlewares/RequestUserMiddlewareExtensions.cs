using Microsoft.AspNetCore.Builder;
namespace ControlInventario.WebApi.Middlewares;
public static class RequestUserMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestUser(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestUserMiddleware>();
    }
}