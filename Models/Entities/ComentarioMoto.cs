using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fachaMotos.Models.Entities
{
    public class ComentarioMoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Contenido { get; set; }
        public int likes { get; set; }
        public int UnLinkes { get; set; }
        public DateTime FechaComentario { get; set; } = DateTime.UtcNow;
        public int BikeId { get; set; }
        public Bike Bike{ get; set; }
        public int UserId { get; set; }
        public User  user { get; set; }
    }

}
