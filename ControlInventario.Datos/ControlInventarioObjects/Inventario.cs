using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Inventario
{
    public int Id { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int Existencia { get; set; }

    public int ProveedorId { get; set; }

    public decimal Costo { get; set; }

    public decimal Precio { get; set; }

    public string CodigoArticulo { get; set; } = null!;

    public string DescripciónArticulo { get; set; } = null!;

    public string CodigoBarra { get; set; } = null!;

    public virtual Proveedor Proveedor { get; set; } = null!;
}
