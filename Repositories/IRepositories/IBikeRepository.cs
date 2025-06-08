namespace fachaMotos.Repositories.IRepositories
{
    using global::fachaMotos.Models.DTOs;
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Repositories
    {
        public interface IBikeRepository
        {
            Task<IEnumerable<Bike>> GetAllBikesAsync();
            Task<Bike> GetBikeByIdAsync(int id);
            Task AddBikeAsync(Bike bike);
            Task UpdateBikeAsync(Bike bike);
            Task DeleteBikeAsync(int id);
            Task<List<BikeWithRatingDTO>> GetBikesWithRatingsAsync();
        }
    }
}