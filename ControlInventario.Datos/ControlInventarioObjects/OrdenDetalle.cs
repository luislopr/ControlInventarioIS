using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class OrdenDetalle
{
    public int IdOrden { get; set; }

    public int IdProveedor { get; set; }

    public int IdArticuloProveedor { get; set; }

    public decimal CostoBolivares { get; set; }

    public decimal? CostoRef { get; set; }

    public decimal DescuentoUnidad { get; set; }

    public decimal? TasaDia { get; set; }

    public int Cantidad { get; set; }

    public decimal CostoTotal { get; set; }

    public virtual CatalogoProveedor IdArticuloProveedorNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
