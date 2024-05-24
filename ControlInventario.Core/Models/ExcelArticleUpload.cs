using System.ComponentModel.DataAnnotations;
using ControlInventario.Data.Models.Helpers;

namespace ControlInventario.Gateway.Models;
public class ExcelArticleUpload
{
    [Column(1)]
    [Required]
    public string Descripción { get; set; }

    [Column(2)]
    [Required]
    public string Código { get; set; }

    [Column(3)]
    [Required]
    public string CódigoBarra { get; set; }

    [Column(4)]
    [Required]
    public double ImpuestoVenta { get; set; }
    [Column(5)]
    [Required]
    public double PrecioDivisa { get; set; }
    [Column(6)]
    [Required]
    public double PrecioVenta { get; set; }

    public bool IsValid()
    {
        if (CódigoBarra == string.Empty || Descripción == string.Empty || Código == string.Empty ||
            CódigoBarra == null || Descripción == null || Código == null)
            return false;
        return true;
    }
}