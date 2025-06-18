using fachaMotos.Models.DTOs;

namespace fachaMotos.Services.IServices
{
    public interface IReviewReactionService
    {
        Task<ReviewReactionDTO> CreateAsync(ReviewReactionCreateDTO dto, int userId);
        Task<List<ReviewReactionDTO>> GetAllAsync();
        Task<ReviewReactionDTO?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
