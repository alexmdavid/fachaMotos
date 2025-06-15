using fachaMotos.Models.DTOs;
using fachaMotos.Services;
using fachaMotos.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fachaMotos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly CloudinaryService _cloudinaryService;

        public BlogController(IBlogService blogService, CloudinaryService cloudinaryService)
        {
            _blogService = blogService;
            _cloudinaryService = cloudinaryService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDTO>>> GetAll()
        {
            return Ok(await _blogService.GetAllBlogsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDTO>> GetById(int id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, BlogDTO blogDto)
        {
            if (id != blogDto.Id) return BadRequest();
            await _blogService.UpdateBlogAsync(blogDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _blogService.DeleteBlogAsync(id);
            return NoContent();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromForm] BlogDTO blogDto, IFormFile? imagen)
        {
            var autor = User.Identity?.Name;

            if (string.IsNullOrEmpty(autor))
            {
                return Unauthorized("No se pudo identificar al usuario.");
            }

            string? urlImagen = null;
            if (imagen != null)
            {
                urlImagen = await _cloudinaryService.SubirImagenAsync(imagen);
            }

            blogDto.ImagenUrl = urlImagen;
            blogDto.Autor = autor; 

            await _blogService.AddBlogAsync(blogDto);

            return CreatedAtAction(nameof(GetById), new { id = blogDto.Id }, blogDto);
        }


        [HttpGet("with-comments")]
        public async Task<ActionResult<List<BlogWithComentDTO>>> GetBlogsWithComments(int pageNumber = 1, int pageSize = 10)
        {
            var blogs = await _blogService.GetBlogWithComents(pageNumber, pageSize);
            if (blogs == null || !blogs.Any()) return NotFound();
            return Ok(blogs);
        }

    }
}
