using fachaMotos.Data;
using fachaMotos.IRepositories;
using fachaMotos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace fachaMotos.Repositories
{
    public class ComentarioBlogReactionRepository : IComentarioBlogReactionRepository
    {
        private readonly AppDbContext _context;

        public ComentarioBlogReactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ComentarioBlogReaction> AddAsync(ComentarioBlogReaction reaction)
        {
            _context.ComentariosBlogReaction.Add(reaction);
            await _context.SaveChangesAsync();
            return reaction;
        }

        public async Task<List<ComentarioBlogReaction>> GetAllAsync()
        {
            return await _context.ComentariosBlogReaction
                .Include(r => r.Usuario)
                .ToListAsync();
        }

        public async Task<ComentarioBlogReaction?> GetByIdAsync(int id)
        {
            return await _context.ComentariosBlogReaction
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reaction = await _context.ComentariosBlogReaction.FindAsync(id);
            if (reaction == null) return false;

            _context.ComentariosBlogReaction.Remove(reaction);
            await _context.SaveChangesAsync();
            return true;
        }

        
        public async Task<ComentarioBlogReaction?> GetByUserAndComentarioAsync(int comentarioId, int userId)
        {
            return await _context.ComentariosBlogReaction
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(r => r.ComentarioId == comentarioId && r.UserId == userId);
        }
        public async Task<ComentarioBlogReaction> UpdateAsync(ComentarioBlogReaction reaction)
        {
            _context.ComentariosBlogReaction.Update(reaction);
            await _context.SaveChangesAsync();
            return reaction;
        }

        public async Task<ComentarioBlogReaction?> GetByConditionAsync(Expression<Func<ComentarioBlogReaction, bool>> predicate)
        {
            return await _context.ComentariosBlogReaction
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
