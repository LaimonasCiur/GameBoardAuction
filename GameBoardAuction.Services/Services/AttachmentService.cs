using GameBoardAuction.Services.Contracts;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace GameBoardAuction.Services.Services
{
    public class AttachmentService : IAttachmentService
    {
        private IHostingEnvironment _environment;

        public AttachmentService(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void SaveFile() 
        {
            string folderName = "Upload/Profile/";

            string webRootPath = _environment.ContentRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            string extention = "a";
            string fileName = "a" + ".jpg";
            string fullPath = Path.Combine(newPath, fileName);
            string envpath = folderName + "/" + fileName;
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                //file.CopyTo(stream);
            }
        }
    }
}
