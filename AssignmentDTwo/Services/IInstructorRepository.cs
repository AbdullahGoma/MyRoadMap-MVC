using AssignmentDTwo.Models;

namespace AssignmentDTwo.Services
{
    public interface IInstructorRepository
    {
        Guid ID { get; set; }

        int Create(Instructor instructor);
        int Delete(int id);
        List<Instructor> GetAll();
        Instructor GetByID(int id);
        Instructor GetByName(string name);
        List<Instructor> GetStudentByDepartmetnId(int id);
        int Update(int id, Instructor newInstructor);
    }
}