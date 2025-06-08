namespace fachaMotos.Models.DTOs
{
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string ClaveHash { get; set; }
    }
}
