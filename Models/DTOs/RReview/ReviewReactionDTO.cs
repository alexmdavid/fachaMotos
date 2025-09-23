using fachaMotos.Enums;

namespace fachaMotos.Models.DTOs.RReview
{
    public class ReviewReactionDTO
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string UsuarioNombre { get; set; }
        public ReactionType Tipo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
