using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace content.Helpers
{
    class CloudinaryStorage
    {

        private Cloudinary _cloudinary;
        public CloudinaryStorage()
        {
#warning TODO: remove from source control
            Account account = new Account(
                  "cloud id",
                  "something",
                  "something else");

            _cloudinary = new Cloudinary(account);

        }

        public ImageUploadResult UploadFile(string path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path)
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult;
        }
    }
}