using Microsoft.AspNetCore.Mvc;
using NewSecond.Models;
using System.Diagnostics;

namespace NewSecond.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            configuration = _configuration;
        }

        //[Route("Callbythis/{id:int}", Name = "Route1")] // Home/Callbythis/23
        public  IActionResult TestParameter()
        {
            string id = RouteData.Values["id"].ToString();
            return Content(id);
        }

        public IActionResult Index()
        {
            //Exception ec = new Exception();
            //throw ec;
            ViewBag.Name = configuration.GetSection("appname").Value;
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