using Microsoft.AspNetCore.Mvc;
using fachaMotos.Models.Entities;
using fachaMotos.Services.IServices.fachaMotos.Services.IServices;

namespace fachaMotos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _adminService.GetAllAdminsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            return admin == null ? NotFound() : Ok(admin);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Admin admin)
        {
            await _adminService.AddAdminAsync(admin);
            return CreatedAtAction(nameof(GetById), new { id = admin.Id }, admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Admin admin)
        {
            if (id != admin.Id) return BadRequest();
            await _adminService.UpdateAdminAsync(admin);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _adminService.DeleteAdminAsync(id);
            return NoContent();
        }
    }
}
