namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.DTOs.fachaMotos.DTOs;
    using global::fachaMotos.Models.DTOs;

    namespace fachaMotos.Services.IServices
    {
        public interface IUserFavoritosService
        {
            Task<List<FavoritoDto>> ObtenerFavoritosAsync(int userId);
            Task<bool> EsFavoritoAsync(int userId, int bikeId);
            Task AgregarFavoritoAsync(int userId, int bikeId);
            Task QuitarFavoritoAsync(int userId, int bikeId);
        }
    }

}
