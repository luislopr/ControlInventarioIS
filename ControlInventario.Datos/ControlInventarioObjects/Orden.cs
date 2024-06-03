using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Orden
{
    public int Id { get; set; }

    public DateTime FechaOrden { get; set; }

    public int IdProveedor { get; set; }

    public int NumeroOrden { get; set; }

    public int NumeroControl { get; set; }

    public decimal Subtotal { get; set; }

    public decimal TotalImpuesto { get; set; }

    public decimal TotalDescuento { get; set; }

    public decimal TotalNeto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? OrdenReferencia { get; set; }

    public int? TipoOrden { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual TipoOrden? TipoOrdenNavigation { get; set; }
}
