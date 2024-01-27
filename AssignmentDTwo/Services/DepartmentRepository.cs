using AssignmentDTwo.Models;
using NewSecond.Data;

namespace AssignmentDTwo.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        AppDbContext context; //new AppDbContext();
        public DepartmentRepository(AppDbContext _context)
        {
            context = _context;
        }
        //Read All
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        //Read One
        public Department GetByID(int id)
        {
            return context.Departments.FirstOrDefault(s => s.ID == id);
        }
        //Create
        public int Create(Department department)
        {
            context.Departments.Add(department);
            return context.SaveChanges();
        }
        //Update
        public int Update(int id, Department department)
        {
            Department OldDepartment = context.Departments.FirstOrDefault(s => s.ID == id);
            OldDepartment.Name = department.Name;
            return context.SaveChanges();
        }
        //Delete
        public int Delete(int id)
        {
            context.Departments.Remove(context.Departments.FirstOrDefault(s => s.ID == id));
            return context.SaveChanges();
        }
    }
}
