using fachaMotos.Data;
using fachaMotos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using fachaMotos.Repositories.IRepositories.fachaMotos.Repositories;

namespace fachaMotos.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly AppDbContext _context;
        public BikeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddBikeAsync(Bike bike)
        {
            await _context.Bikes.AddAsync(bike);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBikeAsync(int id)
        {
            var bike = await _context.Bikes.FindAsync(id);
            if (bike != null)
            {
                _context.Bikes.Remove(bike);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Bike>> GetAllBikesAsync()
        {
            return await _context.Bikes.ToListAsync();
        }

        public async Task<Bike> GetBikeByIdAsync(int id)
        {
            return await _context.Bikes.FindAsync(id);
        }

        public async Task UpdateBikeAsync(Bike bike)
        {
            _context.Bikes.Update(bike);
            await _context.SaveChangesAsync();
        }
    }
}
