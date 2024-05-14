using System.Net;
namespace ControlInventario.Datos.DTO;
public class DtoBaseResponse
{
    public int StatusCode { get; set; } = (int)HttpStatusCode.OK;
    public bool Success { get; set; } = true;
    public string Message { get; set; } = "Success";
    public string TracTRace { get; set; } = string.Empty;
}
