using Microsoft.AspNetCore.Mvc;

namespace WebAppPWD.Controllers
{
    public class RouteController : Controller
    {
        //r/MEthod1
        //r/MEthod2
        public IActionResult Method1(int age,string name)
        {
            return Content("MEthod1");
        }
        //Route/Method2
        //r2
        public IActionResult Method2()
        {
            return Content("MEthod2");
        }
    }
}
