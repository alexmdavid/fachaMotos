using fachaMotos.Enums;

namespace fachaMotos.Models.Entities
{
    public class ComentarioBlogReaction
    {
        public int Id { get; set; }

        public int ComentarioId { get; set; }
        public ComentarioBlog Comentario{ get; set; }

        public int UserId { get; set; }
        public User Usuario { get; set; }

        public ReactionType Tipo { get; set; }

        public DateTime Fecha { get; set; }
    }
}
