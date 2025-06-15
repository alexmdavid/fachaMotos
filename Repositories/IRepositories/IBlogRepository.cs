
using fachaMotos.Models.DTOs;
using fachaMotos.Models.Entities;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetAllBlogsAsync();
    Task<Blog> GetBlogByIdAsync(int id);
    Task AddBlogAsync(Blog blog);
    Task UpdateBlogAsync(Blog blog);
    Task DeleteBlogAsync(int id);
    Task<List<BlogWithComentDTO>> GetBlogWithComents(int pageNumber, int pageSize);
    
}