
namespace fachaMotos.Models.DTOs
{
    public class BikeDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Año { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public int CilindrajeCC { get; set; }
        public int PotenciaHP { get; set; }
        public double TorqueNm { get; set; }
        public string Motor { get; set; } = string.Empty;
        public string Refrigeracion { get; set; } = string.Empty;
        public int medidaNeumaticoDelantero { get; set; }
        public int medidaNeumaticoTrasero { get; set; }
        public string Transmision { get; set; } = string.Empty;
        public int PesoKg { get; set; }
        public double CapacidadCombustibleL { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
