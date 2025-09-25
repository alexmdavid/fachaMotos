namespace fachaMotos.Services
{
    using global::fachaMotos.Models.DTOs;
    using global::fachaMotos.Models.DTOs.Review;
    using global::fachaMotos.Models.Entities;
    using global::fachaMotos.Repositories.IRepositories;
    using global::fachaMotos.Services.IServices.fachaMotos.Services.IServices;

    namespace fachaMotos.Services
    {
        public class ReviewService : IReviewService
        {
            private readonly IReviewRepository _reviewRepository;
            private readonly IBikeService _bikeService;

            public ReviewService(IReviewRepository reviewRepository, IBikeService bikeService)
            {
                _reviewRepository = reviewRepository;
                _bikeService = bikeService;
            }


            public async Task<IEnumerable<Review>> GetAllReviewsAsync()
            {
                return await _reviewRepository.GetAllReviewsAsync();
            }

            public async Task<Review> GetReviewByIdAsync(int id)
            {
                return await _reviewRepository.GetReviewByIdAsync(id);
            }

            public async Task AddReviewAsync(CrearReviewRequest reviewrequest, int userId)
            {
                var bike = await _bikeService.GetBikeByIdAsync(reviewrequest.BikeId);
                if (bike == null) {
                    throw new Exception("Moto no encontrada");
                }
                var review = new Review
                {
                    UserId = userId,
                    BikeId = reviewrequest.BikeId,
                    Comentario = reviewrequest.Comentario,
                    Calificacion = reviewrequest.Puntuacion
                };
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

            public async Task<List<ReviewDetailsDto>> GetReviewsByBikeIdAsync(int bikeId)
            {
                var reviews = await _reviewRepository.GetReviewsByBikeIdAsync(bikeId);
                if (reviews == null)
                {
                    throw new Exception("moto no existente en la base de datos");
                }
                return reviews.Select(r => new ReviewDetailsDto
                {
                    Id = r.Id,
                    Calificacion = r.Calificacion,
                    Comentario = r.Comentario,
                    Fecha = r.Fecha,
                    UsuarioNombre = r.User?.Nombre,
                    UsuarioCorreo = r.User?.Correo,
                    MotoMarca = r.Bike?.Marca,
                    MotoModelo = r.Bike?.Modelo
                }).ToList();
            }


        }
    }

}
