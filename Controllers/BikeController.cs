using Microsoft.AspNetCore.Mvc;
using fachaMotos.Models.Entities;
using fachaMotos.Services.IServices.fachaMotos.Services.IServices;

namespace fachaMotos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _bikeService;

        public BikeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _bikeService.GetAllBikesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bike = await _bikeService.GetBikeByIdAsync(id);
            return bike == null ? NotFound() : Ok(bike);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bike bike)
        {
            await _bikeService.AddBikeAsync(bike);
            return CreatedAtAction(nameof(GetById), new { id = bike.Id }, bike);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Bike bike)
        {
            if (id != bike.Id) return BadRequest();
            await _bikeService.UpdateBikeAsync(bike);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bikeService.DeleteBikeAsync(id);
            return NoContent();
        }
    }
}
