using fachaMotos.Models.Entities;

namespace fachaMotos.Models.DTOs
{
    public class CrearReviewRequest
    {
        public int BikeId { get; set; }
        public string Comentario { get; set; }
        public int Puntuacion { get; set; }
    }

}
