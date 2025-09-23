namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.DTOs;
    using global::fachaMotos.Models.DTOs.Review;
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Services.IServices
    {
        public interface IReviewService
        {
            Task<IEnumerable<Review>> GetAllReviewsAsync();
            Task<Review> GetReviewByIdAsync(int id);
            Task AddReviewAsync(CrearReviewRequest reviewrequest, int userId);
            Task UpdateReviewAsync(Review review);
            Task DeleteReviewAsync(int id);
            Task<List<ReviewDetailsDto>> GetReviewsByBikeIdAsync(int bikeId);

        }
    }

}
