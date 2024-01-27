using Microsoft.AspNetCore.Mvc;
using NewFirst.Models;

namespace NewFirst.Controllers
{
    // Scaffolding: Generate Code
    public class ProductController : Controller
    {
        // Product/Details/1
        public IActionResult Details(int id)
        {
            Product prod = ProductList.Products.FirstOrDefault(p => p.ID == id);
            // Send To View
            return View("Details",prod);
        }

        public IActionResult GetAll()
        {
            var prod = ProductList.Products;
            // Send To View
            return View("getAll", prod);
        }



        // DomainName/Product/GetInfo
        public string GetInfo() // Action: return File, Content String, View, Json, Open Page, ...
            // Return File: FileResult, Return Content: ContentResult, Return View: ViewResult
        {
            return "Hello From First MVC Action";
        }

        // DomainName/Product/GetContent
        public ContentResult GetContent()
        {
            ContentResult result = new ContentResult();
            result.Content = "Hello From Second Action";
            return result;
        }

        // Return View 
        public ViewResult GetView()
        {
            ViewResult result = new ViewResult();
            result.ViewName = "ShowProduct";   
            // Search Where
                  // Views/Product
                  // Views/Shared
            return result;
        }


        public IActionResult Show(int ID)
        {
            if(ID % 2 == 0)
            {
                //// Declare
                //ContentResult result = new ContentResult();
                //// Set Data
                //result.Content = "Hiiiiiiiiiiii";
                //// Return
                //return result;
                return Content("Hiiiiiiiiiii");
            }
            else
            {
                //ViewResult result = new ViewResult();
                //result.ViewName = "ShowProduct";
                //// Search Where
                //// Views/Product
                //// Views/Shared
                //return result;
                return View("ShowProduct");
                //return Json(new { ID = ID, Name = "Ahmed", Age = 25 });
            }

            //RedirectResult red = new RedirectResult("page.Html");

        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
