using fachaMotos.Models.Entities;
using System.Linq.Expressions;

namespace fachaMotos.IRepositories
{
    public interface IComentarioBlogReactionRepository
    {
        Task<ComentarioBlogReaction> AddAsync(ComentarioBlogReaction reaction);
        Task<List<ComentarioBlogReaction>> GetAllAsync();
        Task<ComentarioBlogReaction?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<ComentarioBlogReaction> UpdateAsync(ComentarioBlogReaction reaction);
        Task<ComentarioBlogReaction?> GetByUserAndComentarioAsync(int comentarioId, int userId);
        Task<ComentarioBlogReaction?> GetByConditionAsync(Expression<Func<ComentarioBlogReaction, bool>> predicate);
    }
}

