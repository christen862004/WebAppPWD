using WebAppPWD.Models;

namespace WebAppPWD.Repository
{
    public class DepartmentRepository : IDepartmentRespoitory
    {
        ITIContext context;
        public string ID { get; set; }

        public DepartmentRepository(ITIContext ctx)
        {
           // context = new ITIContext();//onconsfiure
            context = ctx;
            ID =Guid.NewGuid().ToString();
        }

        public void Delete(int id)
        {
            Department department = GetById(id);
            context.Departments.Remove(department);
        }

        public List<Department> GetAll()
        {
            List<Department> deptList= context.Departments.ToList();
            return deptList;
        }

        public Department GetById(int id)
        {
            return  context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Department obj)
        {
            context.Departments.Add(obj);

        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department obj)
        {
            context.Update(obj);

        }
    }
}
