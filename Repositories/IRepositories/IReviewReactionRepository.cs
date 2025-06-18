using fachaMotos.Models.Entities;

namespace fachaMotos.IRepositories
{
    public interface IReviewReactionRepository
    {
        Task<ReviewReaction> AddAsync(ReviewReaction reaction);
        Task<List<ReviewReaction>> GetAllAsync();
        Task<ReviewReaction?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
