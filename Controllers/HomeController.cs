using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcTest.Models;
using System.Text.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using mvcTest.Models;

namespace mvcTest.Controllers
{
    public class HomeController : Controller
    {
        static string jsonUrl = "https://jsonplaceholder.typicode.com/photos";
        static HttpClient client = new HttpClient();

        public IActionResult Index(int pageLength = 3, int pageNumber = 1)
        {
            Console.WriteLine($"Index starting");
            var photos = GetPhotos(pageLength, pageNumber);
            if (pageLength > 10 || pageLength < 1) { pageLength = 10; } // no sneaky business
            if (pageNumber > photos.Length / pageLength || pageNumber < 1) { pageNumber = 1; }
            ViewData["Pages"] = photos.Length;
            var firstItem = (pageNumber - 1) * pageLength;
            var lastItem = firstItem + pageLength;
            ViewData["Photos"] = photos[firstItem..lastItem];
            ViewData["NumPhotos"] = photos.Length;
            ViewData["PageNumber"] = pageNumber;
            ViewData["PageLength"] = pageLength;
            ViewData["FirstPage"] = pageNumber - 3 > 0 ? pageNumber - 3 : 1;
            ViewData["LastPage"] = pageNumber + 3 <= photos.Length / pageLength ? pageNumber + 3 : photos.Length / pageLength;
            Console.WriteLine("Index done");
            return View();
        }

        public Photo[] GetPhotos(int pageLength, int pageNumber)
        {
            var resp = client.GetStringAsync(jsonUrl);
            Photo[] photos = JsonSerializer.Deserialize<Photo[]>(resp.Result);
            return photos;
        }

    }
}
