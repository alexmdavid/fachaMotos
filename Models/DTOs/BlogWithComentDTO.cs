using fachaMotos.Models.Entities;

namespace fachaMotos.Models.DTOs
{
    public class BlogWithComentDTO
    {
        public BlogDTO Blog { get; set; }
        public List<ComentarioBlogDTO> Comentarios { get; set; } = new List<ComentarioBlogDTO>();
    }

}
