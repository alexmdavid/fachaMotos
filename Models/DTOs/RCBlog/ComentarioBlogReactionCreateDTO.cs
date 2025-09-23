using fachaMotos.Enums;

namespace fachaMotos.Models.DTOs.RCBlog
{
    public class ComentarioBlogReactionCreateDTO
    {
        public int ComentarioId { get; set; }
        public int UserId { get; set; }
        public ReactionType Tipo { get; set; }
    }
}
