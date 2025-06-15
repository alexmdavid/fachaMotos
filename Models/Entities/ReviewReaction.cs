using fachaMotos.Enums;

namespace fachaMotos.Models.Entities
{
    public class ReviewReaction
    {
        public int Id { get; set; }

        public int ReviewId { get; set; }
        public Review Review { get; set; }

        public int UserId { get; set; }
        public User Usuario { get; set; }

        public ReactionType Tipo { get; set; } 

        public DateTime Fecha { get; set; }
    }


}
