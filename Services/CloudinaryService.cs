using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace fachaMotos.Services
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            var account = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:ApiSecret"]
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> SubirImagenAsync(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
                return null;

            using var stream = archivo.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(archivo.FileName, stream),
                Folder = "fachaMotos/blogs"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }
    }
}
