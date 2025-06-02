using fachaMotos.Models.Entities;

namespace fachaMotos.Repositories.IRepositories
{
    public interface IUserFavoritosRepository
    {
        Task<List<Bike>> GetFavoritosByUserIdAsync(int userId);
        Task<bool> EsFavoritoAsync(int userId, int bikeId);
        Task AgregarFavoritoAsync(int userId, int bikeId);
        Task QuitarFavoritoAsync(int userId, int bikeId);
    }

}
