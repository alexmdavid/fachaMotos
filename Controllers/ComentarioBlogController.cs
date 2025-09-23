using fachaMotos.Models.DTOs.CBlog;
using fachaMotos.Models.DTOs.fachaMotos.Models.DTOs;
using fachaMotos.Services;
using fachaMotos.Services.IServices.fachaMotos.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace fachaMotos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioBlogController : ControllerBase
    {
        private readonly IComentarioBlogService _service;

        public ComentarioBlogController(IComentarioBlogService service)
        {
            _service = service;
        }
        private int ObtenerUserId()
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        [HttpPost]
        public async Task<ActionResult<ComentarioBlogDTO>> Create([FromBody] ComentarioBlogCreateDTO dto)
        {
            int userId = ObtenerUserId();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

       
        [HttpGet]
        public async Task<ActionResult<List<ComentarioBlogDTO>>> GetAll()
        {
            var comentarios = await _service.GetAllAsync();
            return Ok(comentarios);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioBlogDTO>> GetById(int id)
        {
            var comentario = await _service.GetByIdAsync(id);
            if (comentario == null) return NotFound();
            return Ok(comentario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);
            if (!eliminado) return NotFound(new { message = "Comentario no encontrado" });

            return NoContent();
        }
    }
}
