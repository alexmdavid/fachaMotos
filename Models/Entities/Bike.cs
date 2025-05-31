using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fachaMotos.Models.Entities
{
    public class Bike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  // Clave primaria

        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Año { get; set; }
        public string Tipo { get; set; } = string.Empty; // ej: naked, deportiva, enduro

        // Especificaciones técnicas
        public int CilindrajeCC { get; set; }
        public int PotenciaHP { get; set; }
        public double TorqueNm { get; set; }
        public string Motor { get; set; } = string.Empty; // ej: monocilíndrico, bicilíndrico
        public string Refrigeracion { get; set; } = string.Empty; // aire, líquido

        public int medidaNeumaticoDelantero { get; set; }

        public int medidaNeumaticoTrasero { get; set; }

        public string Transmision { get; set; } = string.Empty; 
        public int PesoKg { get; set; }
        public double CapacidadCombustibleL { get; set; }

        public string ImagenUrl { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public List<MotoFavorita> MotosFavoritas { get; set; } = new List<MotoFavorita>();

    }

}
