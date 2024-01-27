using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewSecond.Data;
using NewSecond.Models;
using NewSecond.ViewModel;

namespace NewSecond.Controllers
{
    public class PassDataController : Controller
    {
        AppDbContext context; //new AppDbContext();
        public PassDataController(AppDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            #region ViewData and BagData
            ////extra info with model
            //List<string> Branches = new List<string>();
            //Branches.Add("Smart");
            //Branches.Add("Alex");
            //Branches.Add("Mansoura");
            //Branches.Add("Assiut");
            //Branches.Add("Menof");

            //// ViewData, ViewBag send small amount of temporary data
            //// for current request only

            //// Magic String: it problems apears in run time 
            //// Type Casting value ==> Object => View
            //ViewData["BrancheList"] = Branches; // ViewData => dictionary have key string,
            //// value object
            //ViewData["Msg"] = "Hello From Controller";

            ////Magic String
            //ViewBag.date = DateTime.Now.ToString(); // Written in ViewData 
            #endregion

            
            List<Department> departments = context.Departments.ToList();
            #region View Overload
            //1
            //Name view not the same of action &model null
            //return View("ShowAll");
            //2
            //Name view not the same of action &with model 
            //return View("ShowAll", departments);
            //3
            //Name view the same of action & model null
            //return View();
            //4
            //Name view the same of action & with model 
            //return View(departments); 
            #endregion
            return View(departments); // departments: in run time create class inherit from
            // razor page and view recieve it in property 'Model', Model have refernce to 
            // departments
        }

        //ViewData faster than ViewModel

        // ViewModel vs Model
        // Model show class with it's properties => student, department, ...
        // ViewModel => Show class with another class => StudentWithDepartmentViewModel
        // it end with ViewModel
        // ViewModel Cases: Model => Specific Property, Model => Add Extra Info Color
        // Model + Model
        public IActionResult ShowStudents()
        {
            List<Student> studentModel = context.Students.Include(s => s.Department).ToList();

            //Using Anonymous Object 
            //var studentViewModel = from s in studentModel
            //                       where s.DepartmentID == s.Department.Id
            //                       select new { ID = s.Id, StudentName = s.Name, DepartmentName = s.Department.Name };

            //ViewModel

            List<StudentNameWithDepartmentNameViewModel> studentViewModel = new List<StudentNameWithDepartmentNameViewModel>();
            foreach (var item in studentModel)
            {
                StudentNameWithDepartmentNameViewModel student = new StudentNameWithDepartmentNameViewModel();
                student.StudentName = item.Name;
                student.DepartmentName = item.Department.Name;
                student.ID = item.ID;
                studentViewModel.Add(student);
            }
            return View(studentViewModel);
        }

        public IActionResult ShowStudentDetails(int id)
        {
            //ViewModel
            Student studentModel = context.Students.Include(s => s.Department).FirstOrDefault(s => s.ID == id);

            StudentNameWithDepartmentNameViewModel studentViewModel = new StudentNameWithDepartmentNameViewModel();
            // Take Copy From Model set in ViewModel
            studentViewModel.StudentName = studentModel.Name;
            studentViewModel.DepartmentName = studentModel.Department.Name;
            studentViewModel.ID = studentModel.ID;

            if (studentViewModel.DepartmentName == "SD")
                studentViewModel.Color = "green";
            else
                studentViewModel.Color = "red";

            //Using Anonymous Object
            //var studentViewModel = context.Students.Include(s => s.Department).Where(s => s.Id == id)
            //.Select(s => new { ID = s.Id, StudentName = s.Name, DepartmentName = s.Department.Name });

            return View(studentViewModel);
        }


    }
}
