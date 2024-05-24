using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Proveedor
{
    public int Id { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Rif { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string Email { get; set; } = null!;

    public string? Direccion { get; set; }

    public int DiasCredito { get; set; }

    public decimal? DiasPromedioEntrega { get; set; }

    public virtual ICollection<CatalogoProveedor> CatalogoProveedor { get; set; } = new List<CatalogoProveedor>();

    public virtual Factura? Factura { get; set; }
}
