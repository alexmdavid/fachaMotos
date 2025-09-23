namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.DTOs;
    using global::fachaMotos.Models.DTOs.Auth;
    using global::fachaMotos.Models.DTOs.User;
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Services.IServices
    {
        public interface IUserService
        {
            Task<IEnumerable<User>> GetAllUsersAsync();
            Task<User> GetUserByIdAsync(int id);
            Task<UsuarioDTO> RegistrarAsync(RegistroDTO dto);
            Task UpdateUserAsync(UpdateUserDTO user);
            Task DeleteUserAsync(int id);
            Task<AuthResponseDTO> LoginAsync(LoginDTO dto);
        }
    }

}

