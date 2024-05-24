using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int NumeroIdentidad { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Telefono { get; set; }

    public virtual Venta? Venta { get; set; }
}
