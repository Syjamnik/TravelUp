using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace TravelUp.Services.AuxilaryClasses
{
    public interface IImageManager
    {
        string SaveUploadedFiles(List<IFormFile> imgList);
        string SaveUploadedFile(IFormFile img);
        List<string> LoadUploadedFileAddresses(string filePath);
        List<string> DeleteUploadedFiles(string dataFromDb);

    }
}
