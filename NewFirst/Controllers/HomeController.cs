using Microsoft.AspNetCore.Mvc;
using NewFirst.Models;
using System.Diagnostics;

namespace NewFirst.Controllers
{
    public class HomeController : Controller
    {
        // HomeController => Controller => BaseController (HttpContext, HttpRequest, HttpResponse)
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}