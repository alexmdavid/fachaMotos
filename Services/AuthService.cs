using fachaMotos.Models.DTOs;
using fachaMotos.Models.DTOs.fachaMotos.Models.DTOs;
using fachaMotos.Models.Entities;
using fachaMotos.Repositories.IRepositories.fachaMotos.Repositories;
using fachaMotos.Services.IServices;
using fachaMotos.WebConfig;
using System.Data;
using System;

namespace fachaMotos.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
            _httpClient = new HttpClient();
        }

        public async Task<AuthResponseDtoFacebook> LoginWithFacebookAsync(FacebookLoginDto dto)
        {
            var fbUrl = $"https://graph.facebook.com/me?fields=id,name,email&access_token={dto.AccessToken}";
            var response = await _httpClient.GetAsync(fbUrl);

            if (!response.IsSuccessStatusCode)
                throw new UnauthorizedAccessException("Token de Facebook inválido");

            var fbUser = await response.Content.ReadFromJsonAsync<FacebookUserDTO>();

            if (fbUser == null || string.IsNullOrEmpty(fbUser.Email))
                throw new Exception("No se pudo obtener la información del usuario de Facebook");

            var user = await _userRepository.ObtenerPorCorreoAsync(fbUser.Email);
            if (user == null)
            {
                user = new User
                {
                    Nombre = fbUser.Name,
                    Correo = fbUser.Email,
                    Rol = "Cliente"
                };

                await _userRepository.AddUserAsync(user);
            }

            var token = Jwt.GenerarToken(user, _config);
            return new AuthResponseDtoFacebook { Token = token };
        }
       

 public async Task<AuthResponseGoogleDTO> LoginWithGoogleAsync(GoogleLoginDto dto)
        {
            // Usamos el access_token para obtener la info del usuario
            var userInfoUrl = $"https://www.googleapis.com/oauth2/v3/userinfo?access_token={dto.IdToken}";
            var response = await _httpClient.GetAsync(userInfoUrl);

            if (!response.IsSuccessStatusCode)
                throw new UnauthorizedAccessException("Token de Google inválido");

            var payload = await response.Content.ReadFromJsonAsync<GoogleUserDto>();

            if (payload == null || string.IsNullOrEmpty(payload.Email))
                throw new Exception("No se pudo obtener la información del usuario");

            // Buscar o crear el usuario en la base de datos
            var user = await _userRepository.ObtenerPorCorreoAsync(payload.Email);
            if (user == null)
            {
                user = new User
                {
                    Nombre = payload.Name,
                    Correo = payload.Email,
                    Rol = "Cliente",
                    ClaveHash = null // <-- opcional, explícito
                };


                await _userRepository.AddUserAsync(user);
            }

            // Generar el JWT propio
            var token = Jwt.GenerarToken(user, _config);
            return new AuthResponseGoogleDTO { Token = token };
        }

    }
}


