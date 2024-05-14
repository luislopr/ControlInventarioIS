using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class CatalogoProveedor
{
    public int Id { get; set; }

    public int IdProveedor { get; set; }

    public string ArticuloProveedor { get; set; } = null!;

    public string CodigoBarra { get; set; } = null!;

    public decimal Costo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
