using ControlInventario.Datos.ControlInventarioObjects;

namespace ControlInventario.Core.Repositories.Interfaces;
public class DtoUsuario
{
    public DtoUsuario(Usuario usuario)
    {
        this.NombreUsuario = usuario.Login;
        this.NombreCompleto = usuario.NombreCompleto;
        this.FechaCreacion = usuario.FechaCreacion;
        this.Email = usuario.Email;
        this.Id = usuario.Id;
        this.Status = usuario.Estado;
    }
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public TimeOnly FechaCreacion { get; set; }

    public int RoleId { get; set; }
    public string Rol { get; set; } = null!;
    public int Status { get; set; }
}