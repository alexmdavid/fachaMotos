namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.DTOs;
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Services.IServices
    {
        public interface IUserService
        {
            Task<IEnumerable<User>> GetAllUsersAsync();
            Task<User> GetUserByIdAsync(int id);
            Task<UsuarioDTO> RegistrarAsync(RegistroDTO dto);
            Task UpdateUserAsync(User user);
            Task DeleteUserAsync(int id);
            Task<AuthResponseDTO> LoginAsync(LoginDTO dto);
        }
    }

}

