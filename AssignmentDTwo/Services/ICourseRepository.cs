using AssignmentDTwo.Models;

namespace AssignmentDTwo.Services
{
    public interface ICourseRepository
    {
        int Create(Course course);
        int Delete(int id);
        List<Course> GetAll();
        Course GetByID(int id);
        int Update(int id, Course course);
    }
}