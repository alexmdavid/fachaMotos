using fachaMotos.IServices;
using fachaMotos.Models.DTOs.RCBlog;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace fachaMotos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioBlogReactionController : ControllerBase
    {
        private readonly IComentarioBlogReactionService _service;

        public ComentarioBlogReactionController(IComentarioBlogReactionService service)
        {
            _service = service;
        }

        private int ObtenerUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
        [HttpPost]
        public async Task<ActionResult<ComentarioBlogReactionDTO>> Create([FromBody] ComentarioBlogReactionCreateDTO dto)
        {
            var userId = ObtenerUserId();
            var result = await _service.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ComentarioBlogReactionDTO>>> GetAll()
        {
            var reactions = await _service.GetAllAsync();
            return Ok(reactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioBlogReactionDTO>> GetById(int id)
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
