using Microsoft.AspNetCore.Mvc;
using WebAppPWD.Models;

namespace WebAppPWD.Controllers
{
    //Statesless
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();

        public DepartmentController()
        {
            
        }
        public IActionResult Index()
        {
            List<Department> departmentList = context.Departments.ToList();
            return View("Index",departmentList);//Index ,Model List<department>
        }

        //department/details?id=20
        public IActionResult Details(int id)
        {
            Department dept=context.Departments.FirstOrDefault(d=>d.Id==id);
            if(dept==null)
            {
                return NotFound();
            }
            return View("Details", dept);//View NAme= DEtails ,Model= DEpartment
        }
    }
}
