using System.ComponentModel.DataAnnotations;

namespace ControlInventario.Core.Models;
public class RegisterRequestModel
{
    [Required]
    public string NombreUsuario { get; set;}
    [Required]
    public string Email { get; set;}
    [Required]
    public string NombrePersona { get; set;}
    [Required]
    public string Contraseña { get; set;}
    [Required]
    public string LlaveActivación { get; set; }
}