using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Notificacion
{
    public int Id { get; set; }

    public string Mensaje { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public DateTime? FechaVisto { get; set; }

    public int RolDestino { get; set; }
}
