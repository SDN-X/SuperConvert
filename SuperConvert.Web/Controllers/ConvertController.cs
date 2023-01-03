using Microsoft.AspNetCore.Mvc;
using SuperConvert.Extensions;
using System.Globalization;

namespace SuperConvert.Web.Controllers
{
    public class ConvertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GregorianToHijri(string gregorianDate)
        {
            DateTime hijriDate = DateConverter.GregorianToHijri(Convert.ToDateTime(gregorianDate));
            string hijriDateString = hijriDate.ToString("dd-MM-yyyy");
            //int hijriMonth =Convert.ToInt16(hijriDateString.Split('-')[1]);
            string hijriMonth = hijriDateString.Split('-')[1];
            hijriDateString = hijriDateString.Replace($"-{hijriMonth}-", $"-{(Models.Enums.HijriMonthes)Convert.ToInt16(hijriMonth)}-");
            Models.ConvertViewModel model = new Models.ConvertViewModel
            {
                Original = gregorianDate,
                Converted = hijriDateString,
                ConvertType = 1
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult GregorianToHijri()
        {
            Models.ConvertViewModel model = new Models.ConvertViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult JsonToCsv()
        {
            Models.ConvertViewModel model = new Models.ConvertViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult JsonToCsv(string jsonString)
        {
            //TODO Use SuperConvert.Files instead
            if (!jsonString.Contains("["))
                jsonString = jsonString.Insert(0, "[");
            if (!jsonString.Contains("]"))
                jsonString = jsonString.Insert(jsonString.Length, "]");

            string subFolder = "wwwroot/ConvertedFiles/CSVs";
            string path = Path.Combine(Directory.GetCurrentDirectory(), subFolder);
            string fileName = $"SUPER_CONVERT_CSV_ID_{Guid.NewGuid()}";
            var respone = jsonString.ToCsv(path, fileName);
            if (path != null)
            {
                var memory = DownloadSinghFile($"{fileName}.csv", subFolder);

                return File(memory.ToArray(), "text/csv", $"{fileName}.csv");
            }

            Models.ConvertViewModel model = new Models.ConvertViewModel
            {
                Converted = respone,
                Original = jsonString,
            };
            return View(model);
        }

        private MemoryStream DownloadSinghFile(string filename, string uploadPath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), uploadPath, filename);
            var memory = new MemoryStream();
            if (System.IO.File.Exists(path))
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(path);
                var content = new MemoryStream(data);
                memory = content;
                System.IO.File.Delete(path);
            }
            memory.Position = 0;
            return memory;
        }
    }
}
