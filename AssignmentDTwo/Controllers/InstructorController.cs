using AssignmentDTwo.Models;
using AssignmentDTwo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssignmentDTwo.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        //AppDbContext context = new AppDbContext();
        IInstructorRepository instructorRepository;
        IDepartmentRepository departmentService;
        // DI implement Dependence Injection & DIP dependence inversion principle
        public InstructorController(IInstructorRepository _instructorRepository, IDepartmentRepository _departmentService)
        {
            // Dependence Injection do initialize in constructor
            // IoC Container(Service Provider) Create Objects
            instructorRepository = _instructorRepository;
            departmentService = _departmentService;
        }
        public IActionResult Index()
        {
            //List<Instructor> instructors = context.Instructors.ToList();
            return View(instructorRepository.GetAll());
        }

        public IActionResult GetInstructor(int DepartmentID)
        {
            //List<Instructor> instructors = context.Instructors.Where(s => s.DepartmentID == DepartmentID).ToList();
            return PartialView(instructorRepository.GetStudentByDepartmetnId(DepartmentID));
            //return View("Details", context.Instructors.FirstOrDefault());
        }


        public IActionResult TestPartial(int instructorID)
        {
            return PartialView("_InstructorCard", instructorRepository.GetByID(instructorID));
            //return View("Details", context.Instructors.FirstOrDefault());
        }

        public IActionResult TestAjax()
        {
            return View();
        }

        public IActionResult NameExist(string Name, int id) // Remot Read from input
        {
            if(id == 0) // Case Add New Student id = 0
            {
                Instructor instructor = instructorRepository.GetByName(Name);
                if (instructor == null) // Name Not Exist
                    //true 
                    return Json(true);
                else // Name Already Exist
                    //false
                    return Json(false);
            }
            else // Edit
            {
                Instructor instructor = instructorRepository.GetByName(Name);
                if(instructor == null)
                    return Json(true); // Update Name with new value
                else
                {
                    // Object id == id parameter true
                    if(instructor.ID == id) // Name Not Changed
                        return Json(true); 
                    else 
                        return Json(false); // Change In Name with value already found
                }
            }
        }

        public IActionResult Details(int id)
        {
            //Instructor instructor = context.Instructors.FirstOrDefault(x => x.ID == id);
            return View(instructorRepository.GetByID(id));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            Instructor instructor = new Instructor();
            List<Department> departments = departmentService.GetAll();
            ViewData["Departments"] = departments;
            //SelectList Departments = new SelectList(ViewBag.departments, "Id", "Name");
            return View(instructor);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult SaveAdd(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                instructorRepository.Create(instructor);
                return RedirectToAction("index");
            }
            List<Department> departments = departmentService.GetAll();
            ViewData["Departments"] = departments;
            return View("Add", instructor);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            //List<Department> departments = context.Departments.ToList();
            List<Department> departments = departmentService.GetAll();
            ViewData["Departments"] = departments;
            Instructor instructor = instructorRepository.GetByID(id);
            return View(instructor);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost] 
        public IActionResult SaveEdit([FromRoute]int id, Instructor newInstructor)
        {
            if (ModelState.IsValid)
            {
                instructorRepository.Update(id, newInstructor);
                return RedirectToAction("Index");
            }
            List<Department> departments = departmentService.GetAll();
            ViewData["Departments"] = departments;
            return View("Edit", newInstructor);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                instructorRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                // Excepion to Client
                return View("Details");
            }

        }


    }
}
