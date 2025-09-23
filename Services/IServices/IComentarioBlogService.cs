namespace fachaMotos.Services.IServices
{
    using global::fachaMotos.Models.DTOs.fachaMotos.Models.DTOs;
    using global::fachaMotos.Models.DTOs;
    using global::fachaMotos.Models.DTOs.CBlog;

    namespace fachaMotos.Services
    {
        public interface IComentarioBlogService
        {
            Task<ComentarioBlogDTO> CreateAsync(ComentarioBlogCreateDTO dto, int userId);
            Task<List<ComentarioBlogDTO>> GetAllAsync();
            Task<ComentarioBlogDTO?> GetByIdAsync(int id);
            Task<bool> DeleteAsync(int id);

        }
    }

}
