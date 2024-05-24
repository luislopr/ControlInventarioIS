using System.ComponentModel.DataAnnotations;

namespace ControlInventario.WebApi.Models;
public class ArticleRequestModel
{
    [MinLength(5)]
    [Required(ErrorMessage = "Ingrese Código de Barras")]
    public string Barcode { get; set; }


    [Required(ErrorMessage = "Ingrese El Nombre del Artículo")]
    public string ArticleName { get; set; }


    [Required(ErrorMessage = "Ingrese Código del Artículo")]
    public int ArticleCode { get; set; }

    public decimal Tax { get; set; } = 0;
    public decimal PriceVEF { get; set; }
    public decimal? PriceREF { get; set; }
    public bool Status { get; set; } = true;
    public int ArticleId { get; internal set; }

    public bool IsValid()
    {
        if (Barcode == string.Empty || ArticleName == string.Empty || ArticleCode < 1) 
            return false;
        return true;
    }
}

public class ArticleRequestModelExtended : ArticleRequestModel
{
    public new int ArticleId { get; set; }
}

