using fachaMotos.Enums;
using fachaMotos.Models.DTOs;
using fachaMotos.Models.DTOs.fachaMotos.Models.DTOs;
using fachaMotos.Models.Entities;
using fachaMotos.Repositories.IRepositories.fachaMotos.Repositories;
using fachaMotos.Services.IServices.fachaMotos.Services;

namespace fachaMotos.Services
{
    public class ComentarioBlogService : IComentarioBlogService
    {
        private readonly IComentarioBlogRepository _repository;

        public ComentarioBlogService(IComentarioBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<ComentarioBlogDTO> CreateAsync(ComentarioBlogCreateDTO dto, int userId)
        {
            var comentario = new ComentarioBlog
            {
                Contenido = dto.Contenido,
                BlogId = dto.BlogId,
                UsuarioId = userId,
                FechaComentario = DateTime.UtcNow
            };

            var result = await _repository.AddAsync(comentario);

            var fullComentario = await _repository.GetWithUsuarioByIdAsync(result.Id);

            return new ComentarioBlogDTO
            {
                Id = fullComentario.Id,
                Contenido = fullComentario.Contenido,
                Fecha = fullComentario.FechaComentario,
                UsuarioNombre = fullComentario.Usuario?.Nombre ?? "Anónimo",
                UsuarioFotoUrl = fullComentario.Usuario?.ImagenPerfilUrl?? "",
                CantidadLikes = fullComentario.likes,
                CantidadUnlikes = fullComentario.UnLinkes
            };
        }

        public async Task<List<ComentarioBlogDTO>> GetAllAsync()
        {
            var comentarios = await _repository.GetAllWithUsuarioAsync();

            return comentarios.Select(c => new ComentarioBlogDTO
            {
                Id = c.Id,
                Contenido = c.Contenido,
                Fecha = c.FechaComentario,
                UsuarioNombre = c.Usuario?.Nombre ?? "Anónimo",
                UsuarioFotoUrl = c.Usuario?.ImagenPerfilUrl ?? "",
                CantidadLikes = c.Reacciones.Count(r => r.Tipo == ReactionType.Like),
                CantidadUnlikes = c.Reacciones.Count(r => r.Tipo == ReactionType.Unlike)
            }).ToList();
        }

        public async Task<ComentarioBlogDTO?> GetByIdAsync(int id)
        {
            var c = await _repository.GetWithUsuarioByIdAsync(id);
            if (c == null) return null;

            return new ComentarioBlogDTO
            {
                Id = c.Id,
                Contenido = c.Contenido,
                Fecha = c.FechaComentario,
                UsuarioNombre = c.Usuario?.Nombre ?? "Anónimo",
                UsuarioFotoUrl = c.Usuario?.ImagenPerfilUrl ?? "",
                CantidadLikes = c.Reacciones.Count(r => r.Tipo == ReactionType.Like),
                CantidadUnlikes = c.Reacciones.Count(r => r.Tipo == ReactionType.Unlike) 
            };
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
