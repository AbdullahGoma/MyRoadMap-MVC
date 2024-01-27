using NewSecond.Models;

namespace NewSecond.Services
{
    public interface IDepartmentRepository
    {
        int Create(Department department);
        int Delete(int id);
        List<Department> GetAll();
        Department GetByID(int id);
        int Update(int id, Department department);
    }
}