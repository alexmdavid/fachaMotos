using fachaMotos.Data;
using fachaMotos.Models.Entities;
using fachaMotos.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace fachaMotos.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;
        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddBikeAsync(Admin admin)
        {
            await _context.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBikeAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Admin>> GetAllBikesAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin> GetBikeByIdAsync(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task UpdateBikeAsync(Admin admin)
        {
            _context.Update(admin);
            await _context.SaveChangesAsync();
        }
    }
}
