using Microsoft.AspNetCore.Mvc;

namespace ControlInventario.WebApi.Controllers;

public class ArticulosController // : BaseController<>
{
    //private readonly IArticulosRepositorio _repositorioArticulos;

    public ArticulosController() { }//IArticulosRepositorio repositorioArticulos) { _repositorioArticulos = repositorioArticulos; }

    /*[HttpPost]
    public async Task<IActionResult> CargarArticulos([FromBody] List<DtoArticulo> dto, CancellationToken cancellationToken)
    {
        try
        {
            await _repositorioArticulos.CargarArticulos(dto, cancellationToken);
            return Ok(new { Message = "Success" });
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }*/
}