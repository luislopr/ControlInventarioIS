using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Factura
{
    public int Id { get; set; }

    public DateTime FechaFactura { get; set; }

    public int IdProveedor { get; set; }

    public int NumeroFactura { get; set; }

    public int NumeroControl { get; set; }

    public decimal Subtotal { get; set; }

    public decimal TotalImpuesto { get; set; }

    public decimal TotalDescuento { get; set; }

    public decimal TotalNeto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
