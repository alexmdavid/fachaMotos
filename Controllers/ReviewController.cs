using Microsoft.AspNetCore.Mvc;
using fachaMotos.Models.Entities;
using fachaMotos.Services.IServices.fachaMotos.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using fachaMotos.Models.DTOs.Review;

namespace fachaMotos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        private readonly IBikeService _bikeService;

        public ReviewController(IReviewService reviewService, IUserService userService, IBikeService bikeService)
        {
            _reviewService = reviewService;
            _userService = userService;
            _bikeService = bikeService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll() => Ok(await _reviewService.GetAllReviewsAsync());

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            return review == null ? NotFound() : Ok(review);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CrearReviewRequest review)
        {
            var userId = obtenerUserId();
            await _reviewService.AddReviewAsync(review, userId);
            return Ok();
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, Review review)
        {
            if (id != review.Id) return BadRequest();
            await _reviewService.UpdateReviewAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }

        [HttpGet("{bikeId}/reviews")]
        public async Task<IActionResult> GetReviewsByBikeId(int bikeId)
        {
            var reviews = await _reviewService.GetReviewsByBikeIdAsync(bikeId);
            return Ok(reviews);
        }

        [HttpGet("obtenerUserId")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public int obtenerUserId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
