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

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create([FromForm] BlogDTO blogDto, IFormFile? imagen)
        {
            var autor = User.Identity?.Name;
            if (string.IsNullOrEmpty(autor))
                return Unauthorized("No se pudo identificar al usuario.");

            string? urlImagen = null;
            if (imagen != null)
                urlImagen = await _cloudinaryService.SubirImagenAsync(imagen);

            blogDto.ImagenUrl = urlImagen;
            blogDto.Autor = autor;

            await _blogService.AddBlogAsync(blogDto);

            return CreatedAtAction(nameof(GetById), new { id = blogDto.Id }, blogDto);
        }

        [HttpPut("{id}/imagen")]
        [Authorize]
        public async Task<ActionResult> UpdateImage(int id, IFormFile nuevaImagen)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            if (blog == null) return NotFound("Blog no encontrado.");

            string publicIdAnterior = ExtractPublicId(blog.ImagenUrl);

            var nuevaUrl = await _cloudinaryService.ActualizarImagenAsync(nuevaImagen, publicIdAnterior);

            blog.ImagenUrl = nuevaUrl;
            await _blogService.UpdateBlogAsync(blog);

            return Ok(new { mensaje = "Imagen actualizada correctamente", url = nuevaUrl });
        }

        [HttpDelete("{id}/imagen")]
        [Authorize]
        public async Task<ActionResult> DeleteImage(int id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            if (blog == null) return NotFound("Blog no encontrado.");

            string publicId = ExtractPublicId(blog.ImagenUrl);
            if (!string.IsNullOrEmpty(publicId))
            {
                await _cloudinaryService.EliminarImagenAsync(publicId);
                blog.ImagenUrl = null;
                await _blogService.UpdateBlogAsync(blog);
            }

            return Ok("Imagen eliminada correctamente.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateBlog(int id, [FromForm] BlogDTO blogDto, IFormFile? nuevaImagen)
        {
            if (id != blogDto.Id) return BadRequest("El ID no coincide.");
            var blogExistente = await _blogService.GetBlogByIdAsync(id);
            if (blogExistente == null) return NotFound("Blog no encontrado.");
            if (nuevaImagen != null)
            {
                string publicIdAnterior = ExtractPublicId(blogExistente.ImagenUrl);
                var nuevaUrl = await _cloudinaryService.ActualizarImagenAsync(nuevaImagen, publicIdAnterior);
                blogDto.ImagenUrl = nuevaUrl;
            }
            else
            {
                blogDto.ImagenUrl = blogExistente.ImagenUrl;
            }

            await _blogService.UpdateBlogAsync(blogDto);
            return Ok("Blog actualizado correctamente.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteBlog(int id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            if (blog == null) return NotFound("Blog no encontrado.");

            if (!string.IsNullOrEmpty(blog.ImagenUrl))
            {
                string publicId = ExtractPublicId(blog.ImagenUrl);
                await _cloudinaryService.EliminarImagenAsync(publicId);
            }

            await _blogService.DeleteBlogAsync(id);
            return Ok("Blog eliminado correctamente.");
        }

 
        [HttpGet("with-comments")]
        public async Task<ActionResult<List<BlogWithComentDTO>>> GetBlogsWithComments([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var blogs = await _blogService.GetBlogWithComents(pageNumber, pageSize);
            if (blogs == null || !blogs.Any()) return NotFound();
            return Ok(blogs);
        }

        private string ExtractPublicId(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;

            var uri = new Uri(url);
            var filename = Path.GetFileNameWithoutExtension(uri.LocalPath);
            return $"fachaMotos/blogs/{filename}";
        }
    }
}
