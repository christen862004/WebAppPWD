using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppPWD.Filtters;

namespace WebAppPWD.Controllers
{
    [HandelError]
    public class FilttersController : Controller
    {
        
        public IActionResult getUser()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                string name = User.Identity.Name;
                Claim AddressClaim= User.Claims.FirstOrDefault(c => c.Type == "Address");
                string id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;


                return Content($"Welcome Ya {name}Address {AddressClaim.Value}");
            }
            return Content($"Welcome Ya Gust");

            // return RedirectToAction("Login", "Account");
        }

        public IActionResult Method1()
        {
            //    throw new Exception("Metohd1 Throw Exception");
            //  return View();
            return Content("fsdfs");

        }
        //[HandelError]
        public IActionResult Method2()
        {
            throw new Exception("Metohd1 Throw Exception");
            return View();
        }
    }
}
