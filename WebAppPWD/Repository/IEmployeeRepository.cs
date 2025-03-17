using WebAppPWD.Models;

namespace WebAppPWD.Repository
{
    //ISP
    public interface IEmployeeRepository :IGenericRepository<Employee>
    {
        List<Employee> GetByDeptID(int deptID);
    }
}
