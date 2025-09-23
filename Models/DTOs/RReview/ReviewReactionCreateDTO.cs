using fachaMotos.Enums;

namespace fachaMotos.Models.DTOs.RReview
{
    public class ReviewReactionCreateDTO
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public ReactionType Tipo { get; set; }
    }
}
