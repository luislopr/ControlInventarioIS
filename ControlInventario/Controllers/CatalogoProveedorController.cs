using ControlInventario.Core.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using ControlInventario.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlInventario.WebApi.Controllers;

[Authorize]
public class CatalogoProveedorController : BaseController<ICatalogoProveedorRepositorio>
{
    public CatalogoProveedorController(ICatalogoProveedorRepositorio proveedorRepository) : base(proveedorRepository) { }

    [HttpPost]
    public async Task<IActionResult> CrearArticuloProveedorAsync([FromBody] ArticleRequestModel dto, CancellationToken cancellationToken)
            => Ok(await _repositorio.CargarArticulo(dto, cancellationToken));

    [HttpPut]
    public async Task<IActionResult> ActualizarArticuloProveedorAsync([FromBody] ArticleRequestModelExtended dto, CancellationToken cancellationToken)
            => Ok(await _repositorio.ActualizarArticulo(dto, cancellationToken));

    [HttpPost("excel")]
    public async Task<IActionResult> CrearArticulosProveedorAsync(IFormFile dto, int providerId, CancellationToken cancellationToken)
            => Ok(await _repositorio.CargarArticulos(dto, providerId, cancellationToken));

    [HttpGet("excel")]
    public async Task<IActionResult> DescargarFormatoArticulosExcelAsync(CancellationToken cancellationToken)
            => Ok(await _repositorio.GetExcelArticleFormat(cancellationToken));

    [HttpPost("Page")]
    public async Task<IActionResult> ListarPaginaDeArtículosAsync([FromBody] ArticleListRequestModel dto, CancellationToken cancellationToken)
            => Ok(await _repositorio.GetArticleListAsync(dto, cancellationToken));
}