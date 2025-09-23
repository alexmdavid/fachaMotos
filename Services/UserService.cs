using fachaMotos.Models.DTOs.Auth;
using fachaMotos.Models.DTOs.User;
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

        public async Task<UsuarioDTO> RegistrarAsync(RegistroDTO dto)
        {
            if (await _userRepository.ObtenerPorCorreoAsync(dto.Correo) is not null)
                throw new Exception("El correo ya está registrado.");
            var hash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(dto.Contrasena)));
            var nuevo = new User
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                ClaveHash = hash,
                ImagenPerfilUrl = dto.ImagenPerfil
                
            };
            await _userRepository.AddUserAsync(nuevo); 

            return new UsuarioDTO
            {
                Id = nuevo.Id,  
                Nombre = nuevo.Nombre,
                Correo = nuevo.Correo,
               
            };
        }

        public async Task UpdateUserAsync(UpdateUserDTO _user)   
        {
            var user = new User
            {
                Id = _user.Id,
                Nombre = _user.Nombre,
                Correo = _user.Correo,
                ClaveHash = _user.ClaveHash
            };
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
            var token = Jwt.GenerarToken(usuario, _config);
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
