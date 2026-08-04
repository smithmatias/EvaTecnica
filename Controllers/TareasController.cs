using EvaluacionDev.Interfaces;
using EvaluacionDev.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionDev.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareasController : ControllerBase
{
    private readonly ITareasService _tareasService;

    public TareasController(ITareasService tareasService)
    {
        _tareasService = tareasService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TareaDTO>>> GetAll()
    {
        IEnumerable<TareaDTO> tareas = await _tareasService.GetAllAsync();
        return Ok(tareas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TareaDTO>> GetById(int id)
    {
        TareaDTO? tarea = await _tareasService.GetByIdAsync(id);
        if (tarea is null)
        {
            return NotFound();
        }

        return Ok(tarea);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool eliminada = await _tareasService.DeleteAsync(id);
        if (!eliminada)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<TareaDTO>> PatchTarea(int id, [FromBody] PatchTareaDTO patchDto)
    {
        TareaDTO? tarea = await _tareasService.PatchAsync(id, patchDto);
        if (tarea is null)
        {
            return NotFound();
        }

        return Ok(tarea);
    }

    [HttpPost("usuarios")]
    public async Task<ActionResult<UsuarioDTO>> CreateUsuario([FromBody] CreateUsuarioDTO createUsuarioDto)
    {
        UsuarioDTO usuarioCreado = await _tareasService.CreateUsuarioAsync(createUsuarioDto);
        return StatusCode(StatusCodes.Status201Created, usuarioCreado);
    }
}
