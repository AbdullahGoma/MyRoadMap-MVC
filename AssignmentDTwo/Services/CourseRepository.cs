using AssignmentDTwo.Models;
using NewSecond.Data;

namespace AssignmentDTwo.Services
{
    public class CourseRepository : ICourseRepository
    {
        AppDbContext context; //new AppDbContext();
        public CourseRepository(AppDbContext _context)
        {
            context = _context;
        }
        //Read All
        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }
        //Read One
        public Course GetByID(int id)
        {
            return context.Courses.FirstOrDefault(s => s.ID == id);
        }
        //Create
        public int Create(Course course)
        {
            context.Courses.Add(course);
            return context.SaveChanges();
        }
        //Update
        public int Update(int id, Course course)
        {
            Course OldCourse = context.Courses.FirstOrDefault(s => s.ID == id);
            OldCourse.Name = course.Name;
            OldCourse.Degree = course.Degree;
            OldCourse.MinDegree = course.MinDegree;
            OldCourse.DepartmentID = course.DepartmentID;
            return context.SaveChanges();
        }
        //Delete
        public int Delete(int id)
        {
            context.Courses.Remove(context.Courses.FirstOrDefault(s => s.ID == id));
            return context.SaveChanges();
        }
    }
}
