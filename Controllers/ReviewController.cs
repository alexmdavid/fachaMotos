using Microsoft.AspNetCore.Mvc;
using fachaMotos.Models.Entities;
using fachaMotos.Services.IServices.fachaMotos.Services.IServices;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> GetAll() => Ok(await _reviewService.GetAllReviewsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            return review == null ? NotFound() : Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Review review)
        {
            await _reviewService.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetById), new { id = review.Id }, review);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Review review)
        {
            if (id != review.Id) return BadRequest();
            await _reviewService.UpdateReviewAsync(review);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
