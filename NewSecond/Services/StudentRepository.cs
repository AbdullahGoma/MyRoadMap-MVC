using NewSecond.Data;
using NewSecond.Models;

namespace NewSecond.Services
{
    // Services Student Model CRUD & DIP
    public class StudentRepository : IStudentRepository
    {
        AppDbContext context; //new AppDbContext();
        public StudentRepository(AppDbContext _context)
        {
            context = _context;
        }

        public Guid ID { get; set; }
        public StudentRepository()
        {
            ID = Guid.NewGuid();
        }

        //Read All
        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }
        //Read One
        public Student GetByID(int id)
        {
            return context.Students.FirstOrDefault(s => s.ID == id);
        }
        public Student GetByName(string name)
        {
            return context.Students.FirstOrDefault(s => s.Name == name);
        }
        public List<Student> GetStudentByDepartmetnId(int id)
        {
            return context.Students.Where(s => s.DepartmentID == id).ToList();
        }

        //Create
        public int Create(Student student)
        {
            context.Students.Add(student);
            return context.SaveChanges();
        }
        //Update
        public int Update(int id, Student student)
        {
            Student OldStudent = context.Students.FirstOrDefault(s => s.ID == id);
            OldStudent.Age = student.Age;
            OldStudent.Address = student.Address;
            OldStudent.DepartmentID = student.DepartmentID;
            OldStudent.Img = student.Img;
            OldStudent.Name = student.Name;
            return context.SaveChanges();
        }
        //Delete
        public int Delete(int id)
        {
            context.Students.Remove(context.Students.FirstOrDefault(s => s.ID == id));
            return context.SaveChanges();
        }
    }
}
