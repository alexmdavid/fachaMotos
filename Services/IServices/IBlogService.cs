using fachaMotos.Models.DTOs;

namespace fachaMotos.Services.IServices
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDTO>> GetAllBlogsAsync();
        Task<BlogDTO> GetBlogByIdAsync(int id);
        Task AddBlogAsync(BlogDTO blogDto);
        Task UpdateBlogAsync(BlogDTO blogDto);
        Task DeleteBlogAsync(int id);
    }
}
