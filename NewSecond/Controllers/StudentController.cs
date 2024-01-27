using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewSecond.Data;
using NewSecond.Models;
using NewSecond.Services;

namespace NewSecond.Controllers
{
    // Share -ControllerName high level => Controller Factory =>
    // StudentController ... = new StudentController(); // Container
    //[Authorize]
    public class StudentController : Controller
    {
        //AppDbContext context = new AppDbContext();
        IStudentRepository studentService;
        IDepartmentRepository departmentService; 
        // DI implement Dependence Injection & DIP dependence inversion principle
        public StudentController(IStudentRepository _studentService, IDepartmentRepository _departmentService)
        {
            // Dependence Injection do initialize in constructor
            // IoC Container(Service Provider) Create Objects
            studentService = _studentService;
            departmentService = _departmentService;
        }
    
        public IActionResult Index()
        {
            return View(studentService.GetAll());
        }

        //[AllowAnonymous]
        public IActionResult TestAjax()
        {
            return View();
        }

        public IActionResult TestPartial(int StudentID)
        {
            return PartialView("_StudentCard", studentService.GetByID(StudentID));
            //return View("Details", context.Students.FirstOrDefault());
        }

        public IActionResult Details(int id)
        {
            Student student = studentService.GetByID(id);
            return View(student);
        }

        public IActionResult NameExist(string Name, int id)
        {
            if (id == 0) // Case Add New Student id = 0
            {
                Student student = studentService.GetByName(Name);

                if (student == null) // Name Not Exist
                    //true 
                    return Json(true);
                else // Name Already Exist
                    //false
                    return Json(false);
            }
            else // Edit
            {
                Student student = studentService.GetByName(Name);
                if (student == null)
                    return Json(true); // Update Name with new value
                else
                {
                    // Object id == id parameter true
                    if (student.ID == id) // Name Not Changed
                        return Json(true);
                    else 
                        return Json(false); // Change In Name with value already found
                }
            }
        }

        public IActionResult Add()
        {
            List<Department> departments = departmentService.GetAll();
            ViewData["Depts"] = departments;
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public IActionResult SaveAdd(Student student)
        {
            if(ModelState.IsValid) // Function we try in it ModelState must take object
                // if we want to add things in parameters, check it in if statement && id == ..
            {

                studentService.Create(student);
                return RedirectToAction("Index");
            }else if(student.Name != "Ali")
            {
                ModelState.AddModelError("", "Name Must be Ali"); // Not Related to specific model property, Server Side, and shown in summary
            }
            List<Department> departments = departmentService.GetAll();
            ViewData["Depts"] = departments;
            return View("Add", student);
        }

        public IActionResult Edit(int id)
        {
            List<Department> departments = departmentService.GetAll();
            ViewData["Depts"] = departments;
            Student student = studentService.GetByID(id);
            return View(student);
        }

        //[HttpGet] 
        [HttpPost] // To do it post only
        public IActionResult SaveEdit([FromRoute]int id, Student newstudent)
        {
            if(ModelState.IsValid)
            {
                studentService.Update(id, newstudent);
                return RedirectToAction("Index");
            }
            List<Department> departments = departmentService.GetAll();
            ViewData["Depts"] = departments;
            return View("Edit", newstudent);

        }


        public IActionResult Delete(int id)
        {
            try
            {
                studentService.Delete(id);  
                return RedirectToAction("Index");
            }catch
            (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                // Excepion to Client
                return View("Details");
            }

        }

    }
}
