using fachaMotos.Models.DTOs;
using fachaMotos.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace fachaMotos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
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
        public async Task<ActionResult> Create(BlogDTO blogDto)
        {
            await _blogService.AddBlogAsync(blogDto);
            return CreatedAtAction(nameof(GetById), new { id = blogDto.Id }, blogDto);
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
    }
}
