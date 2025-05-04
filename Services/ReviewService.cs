namespace fachaMotos.Services
{
    using global::fachaMotos.Models.Entities;
    using global::fachaMotos.Repositories.IRepositories;
    using global::fachaMotos.Services.IServices.fachaMotos.Services.IServices;

    namespace fachaMotos.Services
    {
        public class ReviewService : IReviewService
        {
            private readonly IReviewRepository _reviewRepository;

            public ReviewService(IReviewRepository reviewRepository)
            {
                _reviewRepository = reviewRepository;
            }

            public async Task<IEnumerable<Review>> GetAllReviewsAsync()
            {
                return await _reviewRepository.GetAllReviewsAsync();
            }

            public async Task<Review> GetReviewByIdAsync(int id)
            {
                return await _reviewRepository.GetReviewByIdAsync(id);
            }

            public async Task AddReviewAsync(Review review)
            {
                await _reviewRepository.AddReviewAsync(review);
            }

            public async Task UpdateReviewAsync(Review review)
            {
                await _reviewRepository.UpdateReviewAsync(review);
            }

            public async Task DeleteReviewAsync(int id)
            {
                await _reviewRepository.DeleteReviewAsync(id);
            }
        }
    }

}
