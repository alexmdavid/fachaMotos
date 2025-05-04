namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Services.IServices
    {
        public interface IBikeService
        {
            Task<IEnumerable<Bike>> GetAllBikesAsync();
            Task<Bike> GetBikeByIdAsync(int id);
            Task AddBikeAsync(Bike bike);
            Task UpdateBikeAsync(Bike bike);
            Task DeleteBikeAsync(int id);
        }
    }

}
