using fachaMotos.Models.DTOs;
using fachaMotos.Services.IServices;
using Microsoft.AspNetCore.Mvc;


namespace fachaMotos.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IAuthService _authService;
        public AuthController(IConfiguration config, IAuthService authService)
        {
            _config = config;
            _authService = authService;

        }
        

        [HttpPost("facebook-login")]
        public async Task<IActionResult> LoginWithFacebook([FromBody] FacebookLoginDto dto)
        {
            var result = await _authService.LoginWithFacebookAsync(dto);
            return Ok(result);
        }

        [HttpPost("google")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleLoginDto dto)
        {
            var result = await _authService.LoginWithGoogleAsync(dto);
            return Ok(result);
        }

    }
}


