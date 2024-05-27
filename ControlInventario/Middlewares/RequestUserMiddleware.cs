using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Datos.DTO;
using System.Security.Claims;

namespace ControlInventario.WebApi.Middlewares;

public class RequestUserMiddleware
{
    private readonly RequestDelegate _next;

    public RequestUserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, IUsuariosRepositorio repository)
    {
        if (httpContext.User.Identity is ClaimsIdentity identity && identity.Claims.Any())
        {
            try
            {
                DtoUser user = new()
                {
                    IdUsuario = Convert.ToInt32(identity.FindFirst("idusuario")?.Value),
                    IdRol = Convert.ToInt32(identity.FindFirst("idrol")?.Value),
                    Email = identity.FindFirst("email").Value
                };
                repository.SetUser(user);
            }
            catch (Exception)
            {
                await _next(httpContext);
            }
        }
        await _next(httpContext);
    }
}