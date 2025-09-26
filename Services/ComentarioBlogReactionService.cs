using fachaMotos.IRepositories;
using fachaMotos.IServices;
using fachaMotos.Models.DTOs.RCBlog;
using fachaMotos.Models.Entities;
using fachaMotos.Repositories;

namespace fachaMotos.Services
{
    public class ComentarioBlogReactionService : IComentarioBlogReactionService
    {
        private readonly IComentarioBlogReactionRepository _repository;

        public ComentarioBlogReactionService(IComentarioBlogReactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<ComentarioBlogReactionDTO> CreateAsync(ComentarioBlogReactionCreateDTO dto, int userId)
        {
          
            var existing = await _repository.GetByConditionAsync(
                r => r.ComentarioId == dto.ComentarioId && r.UserId == userId
            );

            if (existing != null)
            {
                existing.Tipo = dto.Tipo;
                existing.Fecha = DateTime.UtcNow;
                await _repository.UpdateAsync(existing);

                return new ComentarioBlogReactionDTO
                {
                    Id = existing.Id,
                    ComentarioId = existing.ComentarioId,
                    UserId = userId,
                    NombreUsuario = existing.Usuario?.Nombre ?? "Anónimo",
                    Tipo = existing.Tipo,
                    Fecha = existing.Fecha
                };
            }
            var reaction = new ComentarioBlogReaction
            {
                ComentarioId = dto.ComentarioId,
                UserId = userId,
                Tipo = dto.Tipo,
                Fecha = DateTime.UtcNow
            };

            var result = await _repository.AddAsync(reaction);
            var loaded = await _repository.GetByIdAsync(result.Id);

            return new ComentarioBlogReactionDTO
            {
                Id = loaded.Id,
                ComentarioId = loaded.ComentarioId,
                UserId = userId,
                NombreUsuario = loaded.Usuario?.Nombre ?? "Anónimo",
                Tipo = loaded.Tipo,
                Fecha = loaded.Fecha
            };
        }

        public async Task<List<ComentarioBlogReactionDTO>> GetAllAsync()
        {
            var reactions = await _repository.GetAllAsync();

            return reactions.Select(r => new ComentarioBlogReactionDTO
            {
                Id = r.Id,
                ComentarioId = r.ComentarioId,
                UserId = r.UserId,
                NombreUsuario = r.Usuario?.Nombre ?? "Anónimo",
                Tipo = r.Tipo,
                Fecha = r.Fecha
            }).ToList();
        }

        public async Task<ComentarioBlogReactionDTO?> GetByIdAsync(int id)
        {
            var r = await _repository.GetByIdAsync(id);
            if (r == null) return null;

            return new ComentarioBlogReactionDTO
            {
                Id = r.Id,
                ComentarioId = r.ComentarioId,
                UserId = r.UserId,
                NombreUsuario = r.Usuario?.Nombre ?? "Anónimo",
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
