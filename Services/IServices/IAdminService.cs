namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Services.IServices
    {
        public interface IAdminService
        {
            Task<IEnumerable<Admin>> GetAllAdminsAsync();
            Task<Admin> GetAdminByIdAsync(int id);
            Task AddAdminAsync(Admin admin);
            Task UpdateAdminAsync(Admin admin);
            Task DeleteAdminAsync(int id);
        }
    }

}
