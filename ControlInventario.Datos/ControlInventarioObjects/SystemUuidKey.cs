using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class SystemUuidKey
{
    public int Id { get; set; }

    public Guid Uuid { get; set; }

    public TimeOnly CreationDate { get; set; }

    public TimeOnly? ExpirationDate { get; set; }
}
