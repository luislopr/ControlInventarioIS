namespace ControlInventario.Core.Models;
public class SeleccionOrdenRequestModel
{
    public int IdOrden { get; set; }
    public SeleccionDetalle SeleccionDetalle { get; set; }
}

public class SeleccionDetalle
{
    public int IdArticuloProveedor { get; set; }
    public int Cantidad { get; set; }
}