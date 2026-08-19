using EvaluacionDev.Models.DTOs;

namespace EvaluacionDev.Interfaces;

public interface ITareasService
{
    Task<IEnumerable<TareaDTO>> GetAllAsync();
    Task<TareaDTO?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<TareaDTO?> PatchAsync(int id, PatchTareaDTO patchDto);
    Task<UsuarioDTO> CreateUsuarioAsync(CreateUsuarioDTO createUsuarioDto);
}
