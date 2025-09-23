namespace fachaMotos.Models.DTOs.CBlog
{
    public class ComentarioBlogDTO
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioFotoUrl { get; set; }
        public int CantidadLikes { get; set; }
        public int CantidadUnlikes { get; set; }
    }

}
