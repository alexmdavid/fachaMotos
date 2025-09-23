using fachaMotos.Models.DTOs.User;

namespace fachaMotos.Models.DTOs.Auth
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
