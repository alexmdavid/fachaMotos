
namespace fachaMotos.Repositories
{
    using global::fachaMotos.Data;
    using global::fachaMotos.Models.Entities;
    using global::fachaMotos.Repositories.IRepositories.fachaMotos.Repositories;
    using Microsoft.EntityFrameworkCore;

    namespace fachaMotos.Repositories
    {
        public class ComentarioBlogRepository : IComentarioBlogRepository
        {
            private readonly AppDbContext _context;

            public ComentarioBlogRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<ComentarioBlog> AddAsync(ComentarioBlog comentario)
            {
                _context.ComentariosBlog.Add(comentario);
                await _context.SaveChangesAsync();
                return comentario;
            }

            public async Task<List<ComentarioBlog>> GetAllAsync()
            {
                return await _context.ComentariosBlog.ToListAsync();
            }

            public async Task<ComentarioBlog?> GetByIdAsync(int id)
            {
                return await _context.ComentariosBlog.FindAsync(id);
            }

            public async Task<List<ComentarioBlog>> GetAllWithUsuarioAsync()
            {
                return await _context.ComentariosBlog
                    .Include(c => c.Usuario)
                    .ToListAsync();
            }

            public async Task<ComentarioBlog?> GetWithUsuarioByIdAsync(int id)
            {
                return await _context.ComentariosBlog
                    .Include(c => c.Usuario)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }
            public async Task<bool> DeleteAsync(int id)
            {
                var comentario = await _context.ComentariosBlog.FindAsync(id);
                if (comentario == null) return false;

                _context.ComentariosBlog.Remove(comentario);
                await _context.SaveChangesAsync();
                return true;
            }

        }
    }

}
