using fachaMotos.Models.DTOs;

namespace fachaMotos.IServices
{
    public interface IComentarioBlogReactionService
    {
        Task<ComentarioBlogReactionDTO> CreateAsync(ComentarioBlogReactionCreateDTO dto, int userId);
        Task<List<ComentarioBlogReactionDTO>> GetAllAsync();
        Task<ComentarioBlogReactionDTO?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
