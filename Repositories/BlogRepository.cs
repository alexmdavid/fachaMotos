using fachaMotos.Data;
using fachaMotos.Enums;
using fachaMotos.Models.DTOs;
using fachaMotos.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace fachaMotos.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task AddBlogAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBlogAsync(Blog blog)
        {
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlogAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<BlogWithComentDTO>> GetBlogWithComents(int pageNumber, int pageSize)
        {
            var blogs = await _context.Blogs
                .Include(b => b.Comentarios)
                    .ThenInclude(c => c.Usuario)
                .Include(b => b.Comentarios)
                    .ThenInclude(c => c.Reacciones) 
                .OrderBy(b => b.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = blogs.Select(b => new BlogWithComentDTO
            {
                Blog = b,
                Comentarios = b.Comentarios.Select(c => new ComentarioBlogDTO
                {
                    Id = c.Id,
                    Contenido = c.Contenido,
                    Fecha = c.FechaComentario,
                    UsuarioNombre = c.Usuario.Nombre,
                    UsuarioFotoUrl = c.Usuario.ImagenPerfilUrl,
                    CantidadLikes = c.Reacciones.Count(r => r.Tipo == ReactionType.Like),
                    CantidadUnlikes = c.Reacciones.Count(r => r.Tipo == ReactionType.Unlike)
                }).ToList()
            }).ToList();

            return result;
        }


    }
}
