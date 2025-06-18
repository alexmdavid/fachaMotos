using fachaMotos.Models.DTOs;
using fachaMotos.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace fachaMotos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewReactionController : ControllerBase
    {
        private readonly IReviewReactionService _service;

        public ReviewReactionController(IReviewReactionService service)
        {
            _service = service;
        }
        private int ObtenerUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        [HttpPost]
        public async Task<ActionResult<ReviewReactionDTO>> Create([FromBody] ReviewReactionCreateDTO dto)
        {
            var userId = ObtenerUserId();
            var result = await _service.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewReactionDTO>>> GetAll()
        {
            var reactions = await _service.GetAllAsync();
            return Ok(reactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewReactionDTO>> GetById(int id)
        {
            var reaction = await _service.GetByIdAsync(id);
            if (reaction == null) return NotFound();
            return Ok(reaction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
