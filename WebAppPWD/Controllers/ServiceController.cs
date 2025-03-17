using Microsoft.AspNetCore.Mvc;
using WebAppPWD.Repository;

namespace WebAppPWD.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRespoitory deptRepo;

        public ServiceController(IDepartmentRespoitory deptRepo)//constructor
        {
            this.deptRepo = deptRepo;
        }

        public IActionResult Index()//
        {
            ViewBag.ID = deptRepo.ID;
            return View();
        }
    }
}
