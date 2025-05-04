namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Services.IServices
    {
        public interface IReviewService
        {
            Task<IEnumerable<Review>> GetAllReviewsAsync();
            Task<Review> GetReviewByIdAsync(int id);
            Task AddReviewAsync(Review review);
            Task UpdateReviewAsync(Review review);
            Task DeleteReviewAsync(int id);
        }
    }

}
