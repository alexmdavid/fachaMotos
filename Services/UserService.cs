using fachaMotos.Models.DTOs;
using fachaMotos.Models.Entities;
using fachaMotos.Repositories.IRepositories.fachaMotos.Repositories;
using fachaMotos.Services.IServices.fachaMotos.Services.IServices;
using fachaMotos.WebConfig;
using System.Security.Cryptography;
using System.Text;

namespace fachaMotos.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        IConfiguration _config;

        public UserService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginDTO dto)
        {
            var usuario = await _userRepository.ObtenerPorCorreoAsync(dto.Correo);
            if (usuario == null)
                throw new Exception("Usuario no encontrado.");
            var hash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(dto.Clave)));
            if (hash != usuario.ClaveHash)
                throw new Exception("Contraseña incorrecta.");
            var token = Jwt.GenerarToken(usuario, _config["Jwt:Key"]);
            return new AuthResponseDTO
            {
                Token = token,
                Usuario = new UsuarioDTO
                {
                    Id = usuario.Id,
                    Nombre = usuario.Nombre,
                    Correo = usuario.Correo
                }
            };
        }
    }
}
