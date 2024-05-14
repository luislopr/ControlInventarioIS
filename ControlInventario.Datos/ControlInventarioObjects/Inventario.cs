using System;
using System.Collections.Generic;

namespace ControlInventario.Datos.ControlInventarioObjects;

public partial class Inventario
{
    public int Id { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int Existencia { get; set; }

    public int CatalogoProveedorId { get; set; }

    public decimal Costo { get; set; }

    public decimal Precio { get; set; }
}
