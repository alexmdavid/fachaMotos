using fachaMotos.Models.Entities;

namespace fachaMotos.IRepositories
{
    public interface IComentarioBlogReactionRepository
    {
        Task<ComentarioBlogReaction> AddAsync(ComentarioBlogReaction reaction);
        Task<List<ComentarioBlogReaction>> GetAllAsync();
        Task<ComentarioBlogReaction?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}

