namespace fachaMotos.Models.DTOs.Review
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public double Calificacion { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioFotoUrl { get; set; }
        public int CantidadLikes { get; set; }
        public int CantidadUnlikes { get; set; }
    }


}
