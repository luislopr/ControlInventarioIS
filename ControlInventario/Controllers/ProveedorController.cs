using ControlInventario.Core.Repositorios.Interfaces;
using ControlInventario.Datos.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlInventario.WebApi.Controllers;

[Authorize]
public class ProveedorController : BaseController<IProveedorRepositorio>
{
    public ProveedorController(IProveedorRepositorio proveedorRepository) : base(proveedorRepository) { }

    [HttpPost]
    public async Task<IActionResult> CrearProveedorAsync([FromBody] DtoProveedor dto, CancellationToken cancellationToken)
            => Ok(await _repositorio.CrearProveedorAsync(dto, cancellationToken));

    [HttpPut]
    public async Task<IActionResult> ActualizarProveedorAsync([FromBody] DtoProveedor dto, CancellationToken cancellationToken)
            => Ok(await _repositorio.EditarProveedorAsync(dto, cancellationToken));
}