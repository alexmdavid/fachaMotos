namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.DTOs;

    namespace fachaMotos.Services.IServices
    {
        public interface IBikeService
        {
            Task<IEnumerable<BikeDTO>> GetAllBikesAsync();
            Task<BikeDTO> GetBikeByIdAsync(int id);
            Task AddBikeAsync(BikeDTO bike);
            Task UpdateBikeAsync(BikeDTO bike);
            Task DeleteBikeAsync(int id);
            Task<List<BikeWithRatingDTO>> GetBikesWithRatingsAsync();
            Task<List<BikeWithRatingDTO>> GetBikesPagedWithRatingsAsync(int pageNumber, int pageSize);
           


        }
    }

}
