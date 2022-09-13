using Microsoft.AspNetCore.Http;

namespace Dotnet_Core_MVC.Models
{
    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
        //public List<IFormFile> FormFiles { get; set; }
    }
}
