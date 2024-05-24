using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using ControlInventario.Core.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ControlInventario.Core.Repositorios;
using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Core.Models;

namespace ControlInventario.Core.Repositories;

public class AuthRepository(PostgresContext contextFactory, IOptions<AppSettings> appSettings)
    : Repository<PostgresContext, Usuario>(contextFactory, appSettings), IAuthRepository
{
    public bool ValidateToken(string token)
    {
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(base._appSettings.Secret));
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public async Task<string> PostAuthAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        var usuario = await base.GetFirst(b => b.Login == username && b.Contraseña == password, cancellationToken);

        if (usuario == null) throw new InvalidOperationException("Usuario o clave inválida");
        if (usuario.Status == false) throw new InvalidOperationException("Usuario inactivo");

        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim("email", usuario.Email.ToString() ),
                    new Claim("idusuario", usuario.Id.ToString() ),
                    new Claim("idrol", usuario.RoleId.ToString()),
                    new Claim("nombre", usuario.NombreCompleto),
            }),
            Expires = DateTime.UtcNow.AddDays(_appSettings.Expiration),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenRespone = tokenHandler.WriteToken(token);
        return tokenRespone;
    }
    public async Task<string> RegisterAsync(RegisterRequestModel a, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
