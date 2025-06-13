using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fachaMotos.Models.Entities
{
    public class ComentarioBlog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Contenido { get; set; }
        public int likes { get; set; }
        public int  UnLinkes { get; set; }
        public DateTime FechaComentario { get; set; } = DateTime.UtcNow;
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public int UsuarioId { get; set; }
        public User Usuario { get; set; }
    }

}
