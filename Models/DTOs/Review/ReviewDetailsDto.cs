namespace fachaMotos.Models.DTOs.Review
{
    public class ReviewDetailsDto
    {
        public int Id { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioCorreo { get; set; }
        public string MotoMarca { get; set; }
        public string MotoModelo { get; set; }
    }

}
