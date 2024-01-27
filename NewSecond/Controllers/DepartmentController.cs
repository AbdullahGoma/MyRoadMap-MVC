using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewSecond.Data;
using NewSecond.Models;
using NewSecond.Services;

namespace NewSecond.Controllers
{
    //[Authorize]
    public class DepartmentController : Controller
    {
        IDepartmentRepository departmentService;
        IStudentRepository studentService;
        public DepartmentController(IDepartmentRepository _departmentRepository, IStudentRepository _studentService)
        {
            departmentService = _departmentRepository;
            studentService = _studentService;
        }

        // Get All
        [Authorize]
        public IActionResult Index()
        {
            List<Department> departments = departmentService.GetAll();
            return View("Index", departments);
        }

        [Authorize]
        public IActionResult Add()
        {
            Department department = new Department();
            return View(department);
        }

        //[Bind(include: "Name")]
        [HttpPost]
        public IActionResult SaveAdd([Bind(include: "Name, ManagerName")]Department department /*, [FromForm] string name*/)
        {

            if(department.Name != null && department.ManagerName != null)
            {
                departmentService.Create(department);
                return RedirectToAction("index");
            }
            return View("Add", department);
        }

        public IActionResult GetStudents(int id) //DepartmentID
        {
            var students = studentService.GetStudentByDepartmetnId(id);
            return View("ShowAllStudents", students); // Connection Between View and Model
        }


        // Model Binder

        //Primitive Type& Collection
        public IActionResult testBinding(int id, int salary, string name, int[] degree)
        {
            //https://localhost:PortNumber/Department/testBinding?id=1&name=Mohamed&salary=5000&degree[0]=10
            return Content($"OK ID = {id}, Salary = {salary}, Name = {name}, Degree[0] = {degree[0]}");
        }

        //Dictionary?Phones[Ali]=1234&Phones[Mahmoud]=4567
        public IActionResult testBindDectionary(Dictionary<string, int> Phones)
        {
            //https://localhost:PortNumber/Department/testBindDectionary?Phones[Ahmed]=123456&phones[Ali]=132345
            return Content("OK");
        }

        //Object 
        public IActionResult TestBindObject(Department department)
        {
            //https://localhost:PortNumber/Department/TestBindObject/100?name=FullStack&ManagerName=Hussien
            return Content("OK");
        }



        public IActionResult TestHelper(string DepartmentName, List<string> sport, bool football, bool volly, string gender)
        {
            Department department = new Department();
            department.Name = "SD";
            return View(department);
        }


    }
}
