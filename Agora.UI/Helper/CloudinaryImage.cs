using Agora.MODEL.Entities;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net;



namespace Agora.UI.Helper
{
    public class CloudinaryImage
    {
        IConfiguration _configuration;
        [System.Obsolete]
        private IHostingEnvironment _environment;

        [System.Obsolete]
        public CloudinaryImage(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        [System.Obsolete]
        public List<string> LocalUpload(List<ProductPicture> ImageList)
        {

            List<string> ClooudinaryUrlList = new List<string>();

            string path = Path.Combine(_environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (ProductPicture postedFile in ImageList)
            {
                string fileName = Path.GetFileName(postedFile.Image.FileName);
                FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                using (stream)
                {
                    postedFile.Image.CopyTo(stream);

                }

                WebRequest aa = System.Net.WebRequest.Create(stream.Name);
                string ClodinaryPath = CloudinaryUploadImage(aa.RequestUri.AbsolutePath);
                ClooudinaryUrlList.Add(ClodinaryPath);
                RemoveLocalFile(aa.RequestUri.AbsolutePath);

            }
            return ClooudinaryUrlList;
        }
        public void RemoveLocalFile(string FilePath)
        {
            FileInfo fi = new FileInfo(FilePath);
            fi.Delete();
        }
        public string CloudinaryUploadImage(string filename)
        {
            Account account = new Account(_configuration["Cloudinary:CloudName"], _configuration["Cloudinary:APIKey"], _configuration["Cloudinary:APISecret"]);
            Cloudinary cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filename)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.SecureUrl.AbsoluteUri;
        }
        public string CloudinaryDestroyImage(string filename)
        {
            Account account = new Account(_configuration["Cloudinary:CloudName"], _configuration["Cloudinary:APIKey"], _configuration["Cloudinary:APISecret"]);
            Cloudinary cloudinary = new Cloudinary(account);
            string[] urlArray = filename.Split('/');
            string sonadim = urlArray[urlArray.Length - 1];
            string sonyrl = sonadim.Substring(0, sonadim.IndexOf("."));
            var deletionParams = new DeletionParams(sonyrl);
            var deletionResult = cloudinary.Destroy(deletionParams);
            return deletionResult.Result;
        }
    }
}
