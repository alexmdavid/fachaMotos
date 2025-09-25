namespace fachaMotos.Services
{
    using global::fachaMotos.Enums;
    using global::fachaMotos.Models.DTOs;
    using global::fachaMotos.Models.DTOs.Bbike;
    using global::fachaMotos.Models.DTOs.Bike;
    using global::fachaMotos.Models.DTOs.Review;
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

            public async Task<IEnumerable<BikeDTO>> GetAllBikesAsync()
            {
                var bikes = await _bikeRepository.GetAllBikesAsync();
                return bikes.Select(b => new BikeDTO
                {
                    Id = b.Id,
                    Marca = b.Marca,
                    Modelo = b.Modelo,
                    Año = b.Año,
                    Tipo = b.Tipo,
                    CilindrajeCC = b.CilindrajeCC,
                    PotenciaHP = b.PotenciaHP,
                    TorqueNm = b.TorqueNm,
                    Motor = b.Motor,
                    Refrigeracion = b.Refrigeracion,
                    medidaNeumaticoDelantero = b.medidaNeumaticoDelantero,
                    medidaNeumaticoTrasero = b.medidaNeumaticoTrasero,
                    Transmision = b.Transmision,
                    PesoKg = b.PesoKg,
                    CapacidadCombustibleL = b.CapacidadCombustibleL,
                    ImagenUrl = b.ImagenUrl,
                    Descripcion = b.Descripcion
                }).ToList();
            }
            

            public async Task<BikeDTO> GetBikeByIdAsync(int id)
            {
               var bike =  await _bikeRepository.GetBikeByIdAsync(id);
                return new BikeDTO {
                    Id = id,
                    Marca = bike.Marca,
                    Modelo = bike.Modelo,
                    Año = bike.Año,
                    Tipo = bike.Tipo,
                    CilindrajeCC = bike.CilindrajeCC,
                    PotenciaHP = bike.PotenciaHP,
                    TorqueNm = bike.TorqueNm,
                    Motor = bike.Motor,
                    Refrigeracion = bike.Refrigeracion,
                    medidaNeumaticoDelantero = bike.medidaNeumaticoDelantero,
                    medidaNeumaticoTrasero = bike.medidaNeumaticoTrasero,
                    Transmision = bike.Transmision,
                    PesoKg = bike.PesoKg,
                    CapacidadCombustibleL = bike.CapacidadCombustibleL,
                    ImagenUrl = bike.ImagenUrl,
                    Descripcion = bike.Descripcion
                    };
                }

            public async Task AddBikeAsync(BikeDTO _bike)
            {
                var bike = new Bike
                {
                    Id = _bike.Id,
                    Marca = _bike.Marca,
                    Modelo = _bike.Modelo,
                    Año = _bike.Año,
                    Tipo = _bike.Tipo,
                    CilindrajeCC = _bike.CilindrajeCC,
                    PotenciaHP = _bike.PotenciaHP,
                    TorqueNm = _bike.TorqueNm,
                    Motor = _bike.Motor,
                    Refrigeracion = _bike.Refrigeracion,
                    medidaNeumaticoDelantero = _bike.medidaNeumaticoDelantero,
                    medidaNeumaticoTrasero = _bike.medidaNeumaticoTrasero,
                    Transmision = _bike.Transmision,
                    PesoKg = _bike.PesoKg,
                    CapacidadCombustibleL = _bike.CapacidadCombustibleL,
                    ImagenUrl = _bike.ImagenUrl,
                    Descripcion = _bike.Descripcion
                };
                await _bikeRepository.AddBikeAsync(bike);
            }

            public async Task UpdateBikeAsync(BikeDTO _bike)
            {
                var bike = new Bike
                {
                    Id = _bike.Id,
                    Marca = _bike.Marca,
                    Modelo = _bike.Modelo,
                    Año = _bike.Año,
                    Tipo = _bike.Tipo,
                    CilindrajeCC = _bike.CilindrajeCC,
                    PotenciaHP = _bike.PotenciaHP,
                    TorqueNm = _bike.TorqueNm,
                    Motor = _bike.Motor,
                    Refrigeracion = _bike.Refrigeracion,
                    medidaNeumaticoDelantero = _bike.medidaNeumaticoDelantero,
                    medidaNeumaticoTrasero = _bike.medidaNeumaticoTrasero,
                    Transmision = _bike.Transmision,
                    PesoKg = _bike.PesoKg,
                    CapacidadCombustibleL = _bike.CapacidadCombustibleL,
                    ImagenUrl = _bike.ImagenUrl,
                    Descripcion = _bike.Descripcion
                };
                await _bikeRepository.UpdateBikeAsync(bike);
            }

            public async Task DeleteBikeAsync(int id)
            {
                await _bikeRepository.DeleteBikeAsync(id);
            }
            public async Task<List<BikeWithRatingDTO>> GetBikesWithRatingsAsync()
            {
                var bikes = await _bikeRepository.GetAllBikesWithReviewsAsync();

                var result = bikes.Select(b => new BikeWithRatingDTO
                {
                    Bike = b,
                    AvgRating = b.Reviews.Any() ? b.Reviews.Average(r => r.Calificacion) : 0
                })
                .OrderByDescending(x => x.AvgRating)
                .ToList();

                return result;
            }

            public async Task<List<BikeWithRatingDTO>> GetBikesPagedWithRatingsAsync(int pageNumber, int pageSize)
            {
                var bikes = await _bikeRepository.GetBikesPagedWithReviewsAsync(pageNumber, pageSize);

                var result = bikes.Select(b => new BikeWithRatingDTO
                {
                    Bike = b,
                    AvgRating = b.Reviews.Any() ? b.Reviews.Average(r => r.Calificacion) : 0,
                    Reviews = b.Reviews.Select(r => new ReviewDTO
                    {
                        Id = r.Id,
                        Contenido = r.Comentario,
                        Calificacion = r.Calificacion,
                        Fecha = r.Fecha,
                        UsuarioNombre = r.User.Nombre,
                        UsuarioFotoUrl = r.User.ImagenPerfilUrl,
                        CantidadLikes = r.Reacciones.Count(rr => rr.Tipo == ReactionType.Like),
                        CantidadUnlikes = r.Reacciones.Count(rr => rr.Tipo == ReactionType.Unlike)
                    }).ToList()
                }).ToList();

                return result;
            }
        }
    }
}


