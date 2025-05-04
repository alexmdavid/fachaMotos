using fachaMotos.Models.Entities;

namespace fachaMotos.Repositories.IRepositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> GetAllBikesAsync();
        Task<Admin> GetBikeByIdAsync(int id);
        Task AddBikeAsync(Admin admin);
        Task UpdateBikeAsync(Admin admin);
        Task DeleteBikeAsync(int id);
    }
}
