namespace fachaMotos.Models.DTOs.User
{
    public class UpdateUserDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string ClaveHash { get; set; }
    }
}
