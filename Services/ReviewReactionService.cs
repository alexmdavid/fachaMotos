using fachaMotos.IRepositories;
using fachaMotos.Models.DTOs.RReview;
using fachaMotos.Models.Entities;
using fachaMotos.Services.IServices;

namespace fachaMotos.Services
{
    public class ReviewReactionService : IReviewReactionService
    {
        private readonly IReviewReactionRepository _repository;

        public ReviewReactionService(IReviewReactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReviewReactionDTO> CreateAsync(ReviewReactionCreateDTO dto, int userId)
        {
            var reaction = new ReviewReaction
            {
                ReviewId = dto.ReviewId,
                UserId = userId,
                Tipo = dto.Tipo,
                Fecha = DateTime.UtcNow
            };

            var saved = await _repository.AddAsync(reaction);
            var loaded = await _repository.GetByIdAsync(saved.Id);

            return new ReviewReactionDTO
            {
                Id = loaded.Id,
                ReviewId = loaded.ReviewId,
                UserId = loaded.UserId,
                UsuarioNombre = loaded.Usuario?.Nombre ?? "Anónimo",
                Tipo = loaded.Tipo,
                Fecha = loaded.Fecha
            };
        }

        public async Task<List<ReviewReactionDTO>> GetAllAsync()
        {
            var reactions = await _repository.GetAllAsync();

            return reactions.Select(r => new ReviewReactionDTO
            {
                Id = r.Id,
                ReviewId = r.ReviewId,
                UserId = r.UserId,
                UsuarioNombre = r.Usuario?.Nombre ?? "Anónimo",
                Tipo = r.Tipo,
                Fecha = r.Fecha
            }).ToList();
        }

        public async Task<ReviewReactionDTO?> GetByIdAsync(int id)
        {
            var r = await _repository.GetByIdAsync(id);
            if (r == null) return null;

            return new ReviewReactionDTO
            {
                Id = r.Id,
                ReviewId = r.ReviewId,
                UserId = r.UserId,
                UsuarioNombre = r.Usuario?.Nombre ?? "Anónimo",
                Tipo = r.Tipo,
                Fecha = r.Fecha
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
