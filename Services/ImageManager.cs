using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelUp.Services.AuxilaryClasses;

namespace TravelUp.Services
{
    public class ImageManager: IImageManager
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageManager(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

        }

        public List<string> LoadUploadedFileAddresses(string dataFromDb)
        {
            if (String.IsNullOrWhiteSpace(dataFromDb))
            {
                return null;
            }
            else
            {
                return new List<string>(dataFromDb.Split("||"));
            }
        }
        public List<string> DeleteUploadedFiles(string dataFromDb)
        {
            if (String.IsNullOrWhiteSpace(dataFromDb))
            {
                return null;
            }
            else
            {
                var listOfItemsToDelete= new List<string>(dataFromDb.Split("||"));
                foreach (var fileAddress in listOfItemsToDelete)
                {
                    var fullFileAddress = "wwwroot//Images//" + fileAddress;
                    if (File.Exists(fullFileAddress))
                        File.Delete(fullFileAddress);
                }
                return listOfItemsToDelete;
            }
        }
        public string SaveUploadedFile(IFormFile img)
        {
            string uniqueFileName = null;

            if (img != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + img.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public string SaveUploadedFiles(List<IFormFile> imgList)
        {
            if (imgList != null && imgList.Count!=0)
            {
                StringBuilder uniqueFilesName = new StringBuilder();
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                for (int i = 0; i < imgList.Count; i++)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgList[i].FileName;
                    uniqueFilesName.Append(uniqueFileName);

                    if(i != imgList.Count-1)
                        uniqueFilesName.Append("||");

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imgList[i].CopyTo(fileStream);
                    }
                }
                return uniqueFilesName.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
