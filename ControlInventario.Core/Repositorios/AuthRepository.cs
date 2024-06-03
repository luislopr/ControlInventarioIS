using ControlInventario.Datos.ControlInventarioObjects;
using ControlInventario.Core.Repositories.Interfaces;
using ControlInventario.Core.Repositorios.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using ControlInventario.Core.Helpers;
using Microsoft.IdentityModel.Tokens;
using ControlInventario.Core.Models;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;

namespace ControlInventario.Core.Repositories;

public class AuthRepository(PostgresContext contextFactory, IOptions<AppSettings> appSettings,
    ISystemUuidRepositorio systemUuidRepositorio, IUsuariosRepositorio usersRepository) : IAuthRepository
{
    private readonly ISystemUuidRepositorio _systemUuidRepositorio = systemUuidRepositorio;
    private readonly IUsuariosRepositorio _usersRepository = usersRepository;
    private readonly AppSettings _appSettings = appSettings.Value;
    public bool ValidateToken(string token)
    {
        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._appSettings.Secret));
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
        var usuario = await _usersRepository.ObtenerUsuarioCredenciales(username, password, cancellationToken);
        if (usuario == null) throw new InvalidOperationException("Usuario o clave inválida");
        if (usuario.Estado == 1) throw new InvalidOperationException("Usuario inactivo");

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
    public async Task<string> RegisterAsync(RegisterRequestModel datosRegistro, CancellationToken cancellationToken)
    {
        var uuid = await this._systemUuidRepositorio.GetSystemUuidKeyAsync(cancellationToken);
        //no implementado aun en BDD
        /*string hashedKey = this.HashPassword(datosRegistro.LlaveActivación);
        if (uuid.Uuid.ToString() != hashedKey) throw new InvalidOperationException("Llave de activación Invalida");     */

        if (uuid.Uuid.ToString() != datosRegistro.LlaveActivación) throw new InvalidOperationException("Llave de activación Invalida");

        var mainUser = new Usuario
        {
            FechaCreacion = TimeOnly.FromDateTime(DateTime.Now),
            NombreCompleto = datosRegistro.NombrePersona,
            RoleId = _appSettings.Roles.Administrador,
            Contraseña = datosRegistro.Contraseña,
            Login = datosRegistro.NombreUsuario,
            Email = datosRegistro.Email,
        };

        await _usersRepository.CrearUsuario(mainUser, cancellationToken);
        var token = await this.PostAuthAsync(datosRegistro.NombreUsuario, datosRegistro.Contraseña);
        return token;
    }

    // Función para convertir una contraseña a SHA-256
    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
    }
}
