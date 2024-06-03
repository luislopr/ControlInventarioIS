using System.ComponentModel.DataAnnotations;

namespace ControlInventario.WebApi.Models;
public class ArticleRequestModel
{
    [MinLength(5)]
    [Required(ErrorMessage = "Ingrese Código de Barras")]
    public string CodigoBarra { get; set; }


    [Required(ErrorMessage = "Ingrese El Nombre del Artículo")]
    public string NombreArticulo { get; set; }


    [Required(ErrorMessage = "Ingrese Código del Artículo")]
    public int CodigoArticuloExterno { get; set; }
    [Required(ErrorMessage = "Seleccione un proveedor")]
    public int IdProveedor { get; set; }
    public decimal IVA { get; set; } = 0;
    public decimal Costo { get; set; }
    //public decimal? PriceREF { get; set; }
    //public bool Status { get; set; } = true;

    public bool IsValid()
    {
        if (CodigoBarra == string.Empty || NombreArticulo == string.Empty || CodigoArticuloExterno < 1) 
            return false;
        return true;
    }
}

public class ArticleRequestModelExtended : ArticleRequestModel
{
    public new int ArticleId { get; set; }
}

