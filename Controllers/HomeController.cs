using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fileDownload.Models;
using System.Net.Mime;
using System.IO;

namespace fileDownload.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PhysicalFileResult()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "neet.png");
            return new PhysicalFileResult(filePath, MediaTypeNames.Image.Jpeg);
        }

        public IActionResult VirtualFileResult()
        {
            return new VirtualFileResult(@"/Images/wwwroot_neet.png", MediaTypeNames.Image.Jpeg);
        }

        public IActionResult FileContentResult()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "neet.png");
            var file = System.IO.File.ReadAllBytes(filePath);
            return File(file, MediaTypeNames.Image.Jpeg, "neet.png");
        }

        public IActionResult FileContentResultforInline()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "neet.png");
            var file = System.IO.File.ReadAllBytes(filePath);
            return File(file, MediaTypeNames.Image.Jpeg);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
