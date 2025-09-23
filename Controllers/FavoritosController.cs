using fachaMotos.Models.DTOs.UBFavorite;
using fachaMotos.Services.IServices.fachaMotos.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace fachaMotos.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        [Authorize]
        public class FavoritosController : ControllerBase
        {
            private readonly IUserFavoritosService _favoritosService;

            public FavoritosController(IUserFavoritosService favoritosService)
            {
                _favoritosService = favoritosService;
            }

            [HttpGet]
            public async Task<ActionResult<List<FavoritoDto>>> GetFavoritos()
            {
                int userId = ObtenerUserId();
                var favoritos = await _favoritosService.ObtenerFavoritosAsync(userId);
                return Ok(favoritos);
            }

            [HttpPost("{bikeId}")]
            public async Task<IActionResult> AgregarFavorito(int bikeId)
            {
                int userId = ObtenerUserId();
                await _favoritosService.AgregarFavoritoAsync(userId, bikeId);
                return NoContent();
            }

            [HttpDelete("{bikeId}")]
            public async Task<IActionResult> QuitarFavorito(int bikeId)
            {
                int userId = ObtenerUserId();
                await _favoritosService.QuitarFavoritoAsync(userId, bikeId);
                return NoContent();
            }

            [HttpGet("{bikeId}/existe")]
            public async Task<ActionResult<bool>> EsFavorito(int bikeId)
            {
                int userId = ObtenerUserId();
                bool esFavorito = await _favoritosService.EsFavoritoAsync(userId, bikeId);
                return Ok(esFavorito);
            }

            private int ObtenerUserId()
            {
                return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
        }
    }


