using fachaMotos.Models.DTOs.Blog;

namespace fachaMotos.Services.IServices
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDTO>> GetAllBlogsAsync();
        Task<BlogDTO> GetBlogByIdAsync(int id);
        Task AddBlogAsync(BlogDTO blogDto);
        Task UpdateBlogAsync(BlogDTO blogDto);
        Task DeleteBlogAsync(int id);

        Task<List<BlogWithComentDTO>> GetBlogWithComents(int pageNumber, int pageSize);
    }
}
