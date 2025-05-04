namespace fachaMotos.Services
{
    using global::fachaMotos.Models.Entities;
    using global::fachaMotos.Repositories.IRepositories.fachaMotos.Repositories;
    using global::fachaMotos.Services.IServices.fachaMotos.Services.IServices;

    namespace fachaMotos.Services
    {
        public class BikeService : IBikeService
        {
            private readonly IBikeRepository _bikeRepository;

            public BikeService(IBikeRepository bikeRepository)
            {
                _bikeRepository = bikeRepository;
            }

            public async Task<IEnumerable<Bike>> GetAllBikesAsync()
            {
                return await _bikeRepository.GetAllBikesAsync();
            }

            public async Task<Bike> GetBikeByIdAsync(int id)
            {
                return await _bikeRepository.GetBikeByIdAsync(id);
            }

            public async Task AddBikeAsync(Bike bike)
            {
                await _bikeRepository.AddBikeAsync(bike);
            }

            public async Task UpdateBikeAsync(Bike bike)
            {
                await _bikeRepository.UpdateBikeAsync(bike);
            }

            public async Task DeleteBikeAsync(int id)
            {
                await _bikeRepository.DeleteBikeAsync(id);
            }
        }
    }

}
