using WebAppPWD.Models;

namespace WebAppPWD.Repository
{
    public interface IDepartmentRespoitory:IGenericRepository<Department>
    {
        string ID { get; set; }
    }
}
