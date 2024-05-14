using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Usuario
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public TimeOnly FechaCreacion { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
