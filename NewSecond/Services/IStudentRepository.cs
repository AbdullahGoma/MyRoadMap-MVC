using NewSecond.Models;

namespace NewSecond.Services
{
    public interface IStudentRepository
    {
        Guid ID { get; set; }
        int Create(Student student);
        int Delete(int id);
        List<Student> GetAll();
        Student GetByID(int id);
        Student GetByName(string name);
        List<Student> GetStudentByDepartmetnId(int id);
        int Update(int id, Student student);
    }
}