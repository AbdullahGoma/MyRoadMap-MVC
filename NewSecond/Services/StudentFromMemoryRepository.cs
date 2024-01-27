using NewSecond.Models;

namespace NewSecond.Services
{
    public class StudentFromMemoryRepository : IStudentRepository
    {
        List<Student> Students = new List<Student>();
        public StudentFromMemoryRepository()
        {
            Students.Add(new Student() { ID = 1, Name = "Mohamed", Age = 22, Address = "Alex", DepartmentID = 1});
            Students.Add(new Student() { ID = 2, Name = "Ali", Age = 22, Address = "Cairo", DepartmentID = 2 });
        }

        public Guid ID { get; set; }

        public int Create(Student student)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
            return Students;
        }
        //Read One
        public Student GetByID(int id)
        {
            return Students.FirstOrDefault(s => s.ID == id);
        }

        public Student GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentByDepartmetnId(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
