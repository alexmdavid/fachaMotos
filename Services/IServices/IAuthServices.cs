using fachaMotos.Models.DTOs.Auth;
using fachaMotos.Models.DTOs.fachaMotos.Models.DTOs;

namespace fachaMotos.Services.IServices
{
    public interface IAuthService
    {
        Task<AuthResponseDtoFacebook> LoginWithFacebookAsync(FacebookLoginDto dto);
        Task<AuthResponseGoogleDTO> LoginWithGoogleAsync(GoogleLoginDto dto);
    }

}
