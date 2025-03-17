using WebAppPWD.Models;

namespace WebAppPWD.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext ctx)
        {
            context = ctx;//new ITIContext();
        }

        public void Delete(int id)
        {
            Employee emp = GetById(id);
            context.Employees.Remove(emp);
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Insert(Employee obj)
        {
            context.Employees.Add(obj);
        }
        //method new not found in Contact
        public List<Employee> GetByDeptID(int deptID)
        {
            return context.Employees.Where(e => e.DepartmentId == deptID).ToList();
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee obj)
        {
            context.Update(obj);
        }
    }
}
