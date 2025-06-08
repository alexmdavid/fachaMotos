using Microsoft.AspNetCore.Mvc;
using fachaMotos.Models.Entities;
using fachaMotos.Services.IServices.fachaMotos.Services.IServices;
using fachaMotos.Models.DTOs;

namespace fachaMotos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllUsersAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] RegistroDTO dto)
        {
            try
            {
                var usuario = await _userService.RegistrarAsync(dto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDTO user)
        {
            if (id != user.Id) return BadRequest();
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var respuesta = await _userService.LoginAsync(dto);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { mensaje = ex.Message });
            }
        }
    }

}
