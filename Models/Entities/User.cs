using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fachaMotos.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(160)]
        [EmailAddress]
        [Required]
        public string Correo { get; set; }

        [MinLength(8)]
        [Required]
        public string ClaveHash { get; set; }

        public List<UserBikeFavorita> MotosFavoritas { get; set; } = new List<UserBikeFavorita>();

        [Required]
        public string Rol { get; set; }= "usuario";

    }
}
