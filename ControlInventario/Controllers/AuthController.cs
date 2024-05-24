using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Core.Models;
namespace ControlInventario.WebApi.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class AuthController : BaseController<IAuthRepository>
{
    public AuthController(IAuthRepository auth_repositorio) : base(auth_repositorio) { }

    [HttpPost]
    public async Task<IActionResult> PostLoginAsync([FromBody] AuthRequestModel body, CancellationToken cancellationToken)
        => Ok(await _repositorio.PostAuthAsync(body.User, body.Password, cancellationToken));

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestModel body, CancellationToken cancellationToken)
        => Ok(await _repositorio.RegisterAsync(body, cancellationToken));
}