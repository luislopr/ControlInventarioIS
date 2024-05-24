using System.ComponentModel.DataAnnotations;

namespace ControlInventario.Core.Models;

public class AuthRequestModel
{
    //[Required(ErrorMessage =("Campo Parent es Requerido"))]
    //public long Parent { get; set; } 

    [Required(ErrorMessage = "Ingrese el nombre de Usuario")]
    public string User { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingrese la Contraseña")]
    public string Password { get; set; } = string.Empty;
}