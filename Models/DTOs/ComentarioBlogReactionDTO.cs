using fachaMotos.Enums;

namespace fachaMotos.Models.DTOs
{
    public class ComentarioBlogReactionDTO
    {
        public int Id { get; set; }
        public int ComentarioId { get; set; }
        public int UserId { get; set; }
        public string NombreUsuario { get; set; }
        public ReactionType Tipo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
