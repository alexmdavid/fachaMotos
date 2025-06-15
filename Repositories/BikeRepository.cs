using fachaMotos.Data;
using fachaMotos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using fachaMotos.Repositories.IRepositories.fachaMotos.Repositories;
using fachaMotos.Models.DTOs;
using fachaMotos.Enums;

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

        public async Task<List<BikeWithRatingDTO>> GetBikesWithRatingsAsync()
        {
            return await _context.Bikes
                .Select(b => new BikeWithRatingDTO
                {
                    Bike = b,
                    AvgRating = _context.Reviews
                        .Where(r => r.BikeId == b.Id)
                        .Average(r => (double?)r.Calificacion) ?? 0
                })
                .OrderByDescending(x => x.AvgRating)
                .ToListAsync();
        }

        public async Task<List<BikeWithRatingDTO>> GetBikesPagedWithRatingsAsync(int pageNumber, int pageSize)
        {
            var bikes = await _context.Bikes
                        .Include(b => b.Reviews)
                            .ThenInclude(r => r.User)
                        .Include(b => b.Reviews)
                            .ThenInclude(r => r.Reacciones)
                        .OrderBy(b => b.Id)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

                                var result = bikes.Select(b => new BikeWithRatingDTO
                                {
                                    Bike = b,
                                    AvgRating = b.Reviews.Any() ? b.Reviews.Average(r => r.Calificacion) : 0,
                                    Reviews = b.Reviews.Select(r => new ReviewDTO
                                    {
                                        Id = r.Id,
                                        Contenido = r.Comentario,
                                        Calificacion = r.Calificacion,
                                        Fecha = r.Fecha,
                                        UsuarioNombre = r.User.Nombre,
                                        UsuarioFotoUrl = r.User.ImagenPerfilUrl,
                                        CantidadLikes = r.Reacciones.Count(rr => rr.Tipo == ReactionType.Like),
                                        CantidadUnlikes = r.Reacciones.Count(rr => rr.Tipo == ReactionType.Unlike)
                                    }).ToList()

                                }).ToList();
            return result;

        }





    }
}
