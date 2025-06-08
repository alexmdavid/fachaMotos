namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.DTOs;
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Services.IServices
    {
        public interface IBikeService
        {
            Task<IEnumerable<BikeDTO>> GetAllBikesAsync();
            Task<BikeDTO> GetBikeByIdAsync(int id);
            Task AddBikeAsync(BikeDTO bike);
            Task UpdateBikeAsync(BikeDTO bike);
            Task DeleteBikeAsync(int id);
        }
    }

}
