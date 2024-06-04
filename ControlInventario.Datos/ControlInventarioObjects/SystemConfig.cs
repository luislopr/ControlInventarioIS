using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class SystemConfig
{
    public int Id { get; set; }

    public Guid Uuid { get; set; }

    public TimeOnly CreationDate { get; set; }

    public TimeOnly? ExpirationDate { get; set; }

    public int IdMetodoAutoOrden { get; set; }
}
