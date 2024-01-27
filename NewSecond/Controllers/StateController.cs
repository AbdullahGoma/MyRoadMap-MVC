using Microsoft.AspNetCore.Mvc;

namespace NewSecond.Controllers
{
    public class StateController : Controller
    {
        // Cookies (Session Cookie(expiration), PersistentCookie(days))
        public IActionResult SetCookie()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(1);
            Response.Cookies.Append("Color", "Yellow"); // Session Cookie
            Response.Cookies.Append("Username", "Abdullah", cookieOptions); // PersistentCookie
            return Content("Cookie Saves");
        }

        public IActionResult GetCookie()
        {
            string User = Request.Cookies["Username"].ToString();
            string color = Request.Cookies["Color"];
            return Content($"Get Data From Cookie {User}, {color}");
        }

        // Session
        public IActionResult SetState()
        {
            // State Save on 
            string name = "ITI";
            int age = 23;
            HttpContext.Session.SetString("StudentName", name); // Request and Response
            HttpContext.Session.SetInt32("StudentAge", age);

            return Content("Data Saved");
        }

       
        public IActionResult GetState()
        {
            string Name = "NULL";
            int Age = 0;
            if (HttpContext.Session.GetString("StudentName") != null)
            {
                Name = HttpContext.Session.GetString("StudentName");
                Age = (int)HttpContext.Session.GetInt32("StudentAge");
                return Content($"Get Data Success, Name = {Name} \t Age = {Age}");
            }
            return RedirectToAction("SetState");
        }

        // TempData to send Errors
        public IActionResult Set()
        {
            // Set Data in TempData
            TempData["Name"] = "ITI";
            return Content("Data Saved");
        }
        public IActionResult Get1()
        {
            // Get1 Data in TempData
            string name = "Empty";
            if (TempData.ContainsKey("Name"))
            {
                name = TempData["Name"].ToString();
                TempData.Keep("Name"); // Save Name 
            }
            return Content($"Get1 Call and TempData = {name}");
        }
        public IActionResult Get2()
        {
            // Get2 Data in TempData
            string name = "Empty";
            if (TempData.ContainsKey("Name"))
            {
                name = TempData.Peek("Name").ToString();
            }
            return Content($"Get2 Call and TempData = {name}");
        }
    }
}

