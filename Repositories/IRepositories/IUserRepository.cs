﻿namespace fachaMotos.Repositories.IRepositories
{
    using global::fachaMotos.Models.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace fachaMotos.Repositories
    {
        public interface IUserRepository
        {
            Task<IEnumerable<User>> GetAllUsersAsync();
            Task<User> GetUserByIdAsync(int id);
            Task AddUserAsync(User user);
            Task UpdateUserAsync(User user);
            Task DeleteUserAsync(int id);
            Task<User?> ObtenerPorCorreoAsync(string correo);
        }
    }

}
