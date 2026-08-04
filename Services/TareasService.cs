using EvaluacionDev.Data;
using EvaluacionDev.Interfaces;
using EvaluacionDev.Models.DTOs;
using EvaluacionDev.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionDev.Services;

public class TareasService : ITareasService
{
    private readonly AppDbContext _context;

    public TareasService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TareaDTO>> GetAllAsync()
    {
        return await _context.Tareas
            .AsNoTracking()
            .Select(t => new TareaDTO
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                Completada = t.Completada,
                FechaCreacion = t.FechaCreacion,
                FechaVencimiento = t.FechaVencimiento,
                UsuarioId = t.UsuarioId
            })
            .ToListAsync();
    }

    public async Task<TareaDTO?> GetByIdAsync(int id)
    {
        return await _context.Tareas
            .AsNoTracking()
            .Where(t => t.Id == id)
            .Select(t => new TareaDTO
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                Completada = t.Completada,
                FechaCreacion = t.FechaCreacion,
                FechaVencimiento = t.FechaVencimiento,
                UsuarioId = t.UsuarioId
            })
            .FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Tarea? tarea = await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id);
        if (tarea is null)
        {
            return false;
        }

        _context.Tareas.Remove(tarea);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<TareaDTO?> PatchAsync(int id, PatchTareaDTO patchDto)
    {
        Tarea? tarea = await _context.Tareas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        if (tarea is null)
        {
            return null;
        }

        if (patchDto.Titulo is not null)
        {
            tarea.Titulo = patchDto.Titulo;
        }

        if (patchDto.Descripcion is not null)
        {
            tarea.Descripcion = patchDto.Descripcion;
        }

        if (patchDto.Completada.HasValue)
        {
            tarea.Completada = patchDto.Completada.Value;
        }

        if (patchDto.FechaVencimiento.HasValue)
        {
            tarea.FechaVencimiento = patchDto.FechaVencimiento.Value;
        }

        if (patchDto.UsuarioId.HasValue)
        {
            bool existeUsuario = await _context.Usuarios
                .AsNoTracking()
                .AnyAsync(u => u.Id == patchDto.UsuarioId.Value);

            if (!existeUsuario)
            {
                return null;
            }

            tarea.UsuarioId = patchDto.UsuarioId.Value;
        }

        await _context.SaveChangesAsync();

        return new TareaDTO
        {
            Id = tarea.Id,
            Titulo = tarea.Titulo,
            Descripcion = tarea.Descripcion,
            Completada = tarea.Completada,
            FechaCreacion = tarea.FechaCreacion,
            FechaVencimiento = tarea.FechaVencimiento,
            UsuarioId = tarea.UsuarioId
        };
    }

    public async Task<UsuarioDTO> CreateUsuarioAsync(CreateUsuarioDTO createUsuarioDto)
    {
        var nuevoUsuario = new Usuario
        {
            Nombre = createUsuarioDto.Nombre,
            Email = createUsuarioDto.Email,
            Activo = createUsuarioDto.Activo,
            FechaAlta = DateTime.UtcNow
        };

        _context.Usuarios.Add(nuevoUsuario);
        await _context.SaveChangesAsync();

        return new UsuarioDTO
        {
            Id = nuevoUsuario.Id,
            Nombre = nuevoUsuario.Nombre,
            Email = nuevoUsuario.Email,
            Activo = nuevoUsuario.Activo,
            FechaAlta = nuevoUsuario.FechaAlta
        };
    }
}
