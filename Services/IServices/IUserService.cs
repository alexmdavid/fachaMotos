namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Services.IServices
    {
        public interface IUserService
        {
            Task<IEnumerable<User>> GetAllUsersAsync();
            Task<User> GetUserByIdAsync(int id);
            Task AddUserAsync(User user);
            Task UpdateUserAsync(User user);
            Task DeleteUserAsync(int id);
        }
    }

}

