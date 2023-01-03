using Microsoft.AspNetCore.Mvc;

namespace SuperConvert.Web.Controllers
{
    public class ConvertedFilesController : Controller
    {
        [Route("convertedfiles/{fileName}")]
        public IActionResult Index(string fileName)
        {
            if (fileName == "" || fileName == null)
            {
                throw new Exception();
            }
            var memory = DownloadSinghFile(fileName, "wwwwroot/ConvertedFiles/CSVs");
            return File(memory.ToArray(), "text/csv", fileName);
        }

        private MemoryStream DownloadSinghFile(string filename, string uploadPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath, filename);
            var memory = new MemoryStream();
            if (System.IO.File.Exists(path))
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(path);
                var content = new System.IO.MemoryStream(data);
                memory = content;
            }
            memory.Position = 0;
            return memory;
        }
    }
}
