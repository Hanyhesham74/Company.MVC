
namespace Demo.DataAccess.Data.Repostitories
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        int Delete(Department department);
        Department? Get(int id);
        IEnumerable<Department> GetAll();
        int Update(Department department);
    }
}