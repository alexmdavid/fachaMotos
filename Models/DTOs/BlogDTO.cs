using fachaMotos.Models.Entities;

namespace fachaMotos.Models.DTOs
{
        public class BlogDTO
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Contenido { get; set; }
            public DateTime FechaPublicacion { get; set; }
            public string? ImagenUrl { get; set; }
            public string Autor { get; set; } 

            public string Resumen { get; set; }
            public string Etiquetas { get; set; }
    }
}
