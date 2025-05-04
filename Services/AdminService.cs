namespace fachaMotos.Services
{
    using global::fachaMotos.Models.Entities;
    using global::fachaMotos.Repositories.IRepositories;
    using global::fachaMotos.Services.IServices.fachaMotos.Services.IServices;

    namespace fachaMotos.Services
    {
        public class AdminService : IAdminService
        {
            private readonly IAdminRepository _adminRepository;

            public AdminService(IAdminRepository adminRepository)
            {
                _adminRepository = adminRepository;
            }

            public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
            {
                return await _adminRepository.GetAllBikesAsync();
            }

            public async Task<Admin> GetAdminByIdAsync(int id)
            {
                return await _adminRepository.GetBikeByIdAsync(id);
            }

            public async Task AddAdminAsync(Admin admin)
            {
                await _adminRepository.AddBikeAsync(admin);
            }

            public async Task UpdateAdminAsync(Admin admin)
            {
                await _adminRepository.UpdateBikeAsync(admin);
            }

            public async Task DeleteAdminAsync(int id)
            {
                await _adminRepository.DeleteBikeAsync(id);
            }
        }
    }

}
