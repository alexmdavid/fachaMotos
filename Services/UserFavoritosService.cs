namespace fachaMotos.Services
{
    using global::fachaMotos.Models.DTOs.fachaMotos.DTOs;
    using global::fachaMotos.Models.DTOs;
    using global::fachaMotos.Repositories.IRepositories;
    using global::fachaMotos.Services.IServices.fachaMotos.Services.IServices;

    namespace fachaMotos.Services
    {
        public class UserFavoritosService : IUserFavoritosService
        {
            private readonly IUserFavoritosRepository _favoritosRepository;

            public UserFavoritosService(IUserFavoritosRepository favoritosRepository)
            {
                _favoritosRepository = favoritosRepository;
            }

            public async Task<List<FavoritoDto>> ObtenerFavoritosAsync(int userId)
            {
                var favoritos = await _favoritosRepository.GetFavoritosByUserIdAsync(userId);

                return favoritos.Select(b => new FavoritoDto
                {
                    BikeId = b.Id,
                    Marca = b.Marca,
                    Modelo = b.Modelo,
                    Año = b.Año,
                    ImagenUrl = b.ImagenUrl
                }).ToList();
            }

            public async Task<bool> EsFavoritoAsync(int userId, int bikeId)
            {
                return await _favoritosRepository.EsFavoritoAsync(userId, bikeId);
            }

            public async Task AgregarFavoritoAsync(int userId, int bikeId)
            {
                var yaEsFavorito = await _favoritosRepository.EsFavoritoAsync(userId, bikeId);
                if (!yaEsFavorito)
                {
                    await _favoritosRepository.AgregarFavoritoAsync(userId, bikeId);
                }
            }

            public async Task QuitarFavoritoAsync(int userId, int bikeId)
            {
                await _favoritosRepository.QuitarFavoritoAsync(userId, bikeId);
            }
        }
    }

}
