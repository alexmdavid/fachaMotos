using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fachaMotos.Models.Entities
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public string Autor { get; set; }

        public string? Categoria { get; set; } 
        public string? ImagenUrl { get; set; }
        public string? Etiquetas { get; set; } 
        public List<ComentarioBlog> Comentarios { get; set; } = new List<ComentarioBlog>();
    }

}
