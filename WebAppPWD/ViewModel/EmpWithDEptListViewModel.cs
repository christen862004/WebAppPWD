using System.ComponentModel.DataAnnotations.Schema;
using WebAppPWD.Models;

namespace WebAppPWD.ViewModel
{
    public class EmpWithDEptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int Salary { get; set; }
        public string? ImageURL { get; set; }
        public string? JobTitle { get; set; }

        public int DepartmentId { get; set; }
        //+ List<department>
        public List<Department> DepartmentList { get; set; }
    }
}
