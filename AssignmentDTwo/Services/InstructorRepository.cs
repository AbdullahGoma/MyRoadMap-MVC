using AssignmentDTwo.Models;
using NewSecond.Data;

namespace AssignmentDTwo.Services
{
    public class InstructorRepository : IInstructorRepository
    {
        AppDbContext context; //new AppDbContext();
        public InstructorRepository(AppDbContext _context)
        {
            context = _context;
        }

        public Guid ID { get; set; }
        public InstructorRepository()
        {
            ID = Guid.NewGuid();
        }

        //Read All
        public List<Instructor> GetAll()
        {
            return context.Instructors.ToList();
        }
        //Read One
        public Instructor GetByID(int id)
        {
            return context.Instructors.FirstOrDefault(s => s.ID == id);
        }

        public Instructor GetByName(string name)
        {
            return context.Instructors.FirstOrDefault(s => s.Name == name);
        }

        public List<Instructor> GetStudentByDepartmetnId(int id)
        {
            return context.Instructors.Where(s => s.DepartmentID == id).ToList();
        }

        //Create
        public int Create(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            return context.SaveChanges();
        }
        //Update
        public int Update(int id, Instructor newInstructor)
        {
            Instructor instructor = context.Instructors.FirstOrDefault(s => s.ID == id);
            instructor.Name = newInstructor.Name;
            instructor.Address = newInstructor.Address;
            instructor.Birthdate = newInstructor.Birthdate;
            instructor.Img = newInstructor.Img;
            instructor.DepartmentID = newInstructor.DepartmentID;
            instructor.Salary = newInstructor.Salary;
            return context.SaveChanges();
        }
        //Delete
        public int Delete(int id)
        {
            context.Instructors.Remove(context.Instructors.FirstOrDefault(s => s.ID == id));
            return context.SaveChanges();
        }
    }
}
