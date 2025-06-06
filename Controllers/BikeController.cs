﻿using Microsoft.AspNetCore.Mvc;
using fachaMotos.Models.Entities;
using fachaMotos.Services.IServices.fachaMotos.Services.IServices;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(Bike bike)
        {
            await _bikeService.AddBikeAsync(bike);
            return CreatedAtAction(nameof(GetById), new { id = bike.Id }, bike);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update(int id, Bike bike)
        {
            if (id != bike.Id) return BadRequest();
            await _bikeService.UpdateBikeAsync(bike);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bikeService.DeleteBikeAsync(id);
            return NoContent();
        }
        [HttpPost("bulk")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CreateMultiple([FromBody] List<Bike> bikes)
        {
            if (bikes == null || !bikes.Any())
                return BadRequest("La lista de motos no puede estar vacía.");

            foreach (var bike in bikes)
            {
                await _bikeService.AddBikeAsync(bike);
            }

            return Ok(new { message = $"{bikes.Count} motos agregadas exitosamente." });
        }

    }
}
