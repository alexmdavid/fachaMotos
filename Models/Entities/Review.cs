using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fachaMotos.Models.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Range(1, 5)]
        public int Calificacion { get; set; }
        [Required]
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public int BikeId { get; set; }
        public User User { get; set; }
        public Bike Bike { get; set; }

        public List<ReviewReaction> Reacciones { get; set; } = new List<ReviewReaction>();

    }
}
