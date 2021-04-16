using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace mvcTest.Controllers
{
    public class ApiController : Controller
    {
        public string Index()
        {
            return "This is my default action...";
        }
    }
}