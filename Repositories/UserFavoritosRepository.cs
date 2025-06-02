using fachaMotos.Data;
using fachaMotos.Models.Entities;
using fachaMotos.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace fachaMotos.Repositories
{
    public class UserFavoritosRepository : IUserFavoritosRepository
    {
        private readonly AppDbContext _context;

        public UserFavoritosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bike>> GetFavoritosByUserIdAsync(int userId)
        {
            return await _context.ListasDeFavoritos
                .Where(f => f.UserId == userId)
                .Include(f => f.Bike)
                .Select(f => f.Bike)
                .ToListAsync();
        }

        public async Task<bool> EsFavoritoAsync(int userId, int bikeId)
        {
            return await _context.ListasDeFavoritos.AnyAsync(f => f.UserId == userId && f.BikeId == bikeId);
        }

        public async Task AgregarFavoritoAsync(int userId, int bikeId)
        {
            var favorito = new UserBikeFavorita { UserId = userId, BikeId = bikeId };
            _context.ListasDeFavoritos.Add(favorito);
            await _context.SaveChangesAsync();
        }

        public async Task QuitarFavoritoAsync(int userId, int bikeId)
        {
            var favorito = await _context.ListasDeFavoritos
                .FirstOrDefaultAsync(f => f.UserId == userId && f.BikeId == bikeId);

            if (favorito != null)
            {
                _context.ListasDeFavoritos.Remove(favorito);
                await _context.SaveChangesAsync();
            }
        }
    }

}
