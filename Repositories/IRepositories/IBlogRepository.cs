
using fachaMotos.Models.Entities;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetAllBlogsAsync();
    Task<Blog> GetBlogByIdAsync(int id);
    Task AddBlogAsync(Blog blog);
    Task UpdateBlogAsync(Blog blog);
    Task DeleteBlogAsync(int id);

}