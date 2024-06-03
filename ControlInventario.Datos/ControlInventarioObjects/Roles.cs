using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Roles
{
    public int Id { get; set; }

    public string Rol { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
