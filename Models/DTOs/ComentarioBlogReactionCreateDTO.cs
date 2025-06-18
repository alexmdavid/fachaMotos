using fachaMotos.Enums;

namespace fachaMotos.Models.DTOs
{
    public class ComentarioBlogReactionCreateDTO
    {
        public int ComentarioId { get; set; }
        public int UserId { get; set; }
        public ReactionType Tipo { get; set; }
    }
}
