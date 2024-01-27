using AssignmentDTwo.Models;
using AssignmentDTwo.Services;
using Microsoft.AspNetCore.Mvc;
using NewSecond.Data;

namespace AssignmentDTwo.Controllers
{
    public class DepartmentController : Controller
    {
        //AppDbContext context = new AppDbContext();
        IInstructorRepository instructorRepository;
        IDepartmentRepository departmentService;
        // DI implement Dependence Injection & DIP dependence inversion principle
        public DepartmentController(IInstructorRepository _instructorRepository, IDepartmentRepository _departmentService)
        {
            // Dependence Injection do initialize in constructor
            // IoC Container(Service Provider) Create Objects
            instructorRepository = _instructorRepository;
            departmentService = _departmentService;
        }
        public IActionResult Index()
        {
            //List<Department> departments = context.Departments.ToList();
            return View(departmentService.GetAll());
        }
    }
}
