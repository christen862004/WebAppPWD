using WebAppPWD.Models;

namespace WebAppPWD.Repository
{
    public class EmpFromMemeoryReposiotory:IEmployeeRepository
    {
        List<Employee> employees;
        public EmpFromMemeoryReposiotory()
        {
            employees = new List<Employee>() { 
                new Employee(){ Id=100,Name="Ahmed"},
                new Employee(){ Id=200,Name="BAsant"}
            };
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
           return employees;
        }

        public List<Employee> GetByDeptID(int deptID)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
