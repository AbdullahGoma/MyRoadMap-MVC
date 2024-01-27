using Microsoft.AspNetCore.Mvc;
using NewSecond.Services;

namespace NewSecond.Controllers
{
    public class ServiceController : Controller
    {
        //IDepartmentRepository departmentService;
        IStudentRepository studentService;
        public ServiceController(IStudentRepository _studentService) // inject
        {
            studentService = _studentService;
        }

        public IActionResult Index()
        {
            // ID Will be the same
            ViewData["ServiceID"] = studentService.ID;
            return View();
        }
    }
}
