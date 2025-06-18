using fachaMotos.Data;
using fachaMotos.IRepositories;
using fachaMotos.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace fachaMotos.Repositories
{
    public class ReviewReactionRepository : IReviewReactionRepository
    {
        private readonly AppDbContext _context;

        public ReviewReactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewReaction> AddAsync(ReviewReaction reaction)
        {
            _context.ReviewReactions.Add(reaction);
            await _context.SaveChangesAsync();
            return reaction;
        }

        public async Task<List<ReviewReaction>> GetAllAsync()
        {
            return await _context.ReviewReactions
                .Include(r => r.Usuario)
                .ToListAsync();
        }

        public async Task<ReviewReaction?> GetByIdAsync(int id)
        {
            return await _context.ReviewReactions
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reaction = await _context.ReviewReactions.FindAsync(id);
            if (reaction == null) return false;

            _context.ReviewReactions.Remove(reaction);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
