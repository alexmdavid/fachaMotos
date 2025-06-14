using fachaMotos.Models.DTOs;
using fachaMotos.Models.Entities;
using fachaMotos.Services.IServices;

namespace fachaMotos.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<BlogDTO>> GetAllBlogsAsync()
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();
            return blogs.Select(b => new BlogDTO
            {
                Id = b.Id,
                Titulo = b.Titulo,
                Contenido = b.Contenido,
                FechaPublicacion = b.FechaPublicacion
            });
        }

        public async Task<BlogDTO> GetBlogByIdAsync(int id)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(id);
            if (blog == null) return null;

            return new BlogDTO
            {
                Id = blog.Id,
                Titulo = blog.Titulo,
                Contenido = blog.Contenido,
                FechaPublicacion = blog.FechaPublicacion
            };
        }

        public async Task AddBlogAsync(BlogDTO blogDto)
        {
            var blog = new Blog
            {
                Titulo = blogDto.Titulo,
                Contenido = blogDto.Contenido,
                FechaPublicacion = blogDto.FechaPublicacion
            };

            await _blogRepository.AddBlogAsync(blog);
        }

        public async Task UpdateBlogAsync(BlogDTO blogDto)
        {
            var blog = new Blog
            {
                Id = blogDto.Id,
                Titulo = blogDto.Titulo,
                Contenido = blogDto.Contenido,
                FechaPublicacion = blogDto.FechaPublicacion
            };

            await _blogRepository.UpdateBlogAsync(blog);
        }

        public async Task DeleteBlogAsync(int id)
        {
            await _blogRepository.DeleteBlogAsync(id);
        }
    }
}

