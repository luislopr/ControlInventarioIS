using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Venta
{
    public int Id { get; set; }

    public int NumeroFactura { get; set; }

    public TimeOnly FechaFactura { get; set; }

    public decimal PorcentajeIva { get; set; }

    public decimal MontoBase { get; set; }

    public decimal MontoIva { get; set; }

    public int NumeroControl { get; set; }

    public int ClienteId { get; set; }

    public TimeOnly FechaCreacion { get; set; }

    public virtual Cliente IdNavigation { get; set; } = null!;
}
