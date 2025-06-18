namespace fachaMotos.Repositories.IRepositories
{
    using global::fachaMotos.Models.Entities;

    namespace fachaMotos.Repositories
    {
        public interface IComentarioBlogRepository
        {
            Task<ComentarioBlog> AddAsync(ComentarioBlog comentario);
            Task<List<ComentarioBlog>> GetAllAsync();
            Task<ComentarioBlog?> GetByIdAsync(int id);
            Task<List<ComentarioBlog>> GetAllWithUsuarioAsync();
            Task<ComentarioBlog?> GetWithUsuarioByIdAsync(int id);
            Task<bool> DeleteAsync(int id);


        }
    }

}
