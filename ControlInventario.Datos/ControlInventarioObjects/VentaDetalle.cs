using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class VentaDetalle
{
    public int IdVenta { get; set; }

    public string Articulo { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Iva { get; set; }

    public decimal Descuento { get; set; }

    public decimal? PrecioTotal { get; set; }

    public string? CodigoArticulo { get; set; }
}
