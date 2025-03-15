using Microsoft.AspNetCore.Mvc;

namespace WebAppPWD.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession()
        {
            //logic 
            //state managment variable name
            
            HttpContext.Session.SetString("Name","Ahmed");//wirte /read from session per used
            HttpContext.Session.SetInt32("Age", 25);
            //logic
            return Content("Data Saved on Session");
        }
       
        //store data VI (Secure)
        public IActionResult GetSession()
        {
            //logic
            string n = HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");
            //logic.....
            return Content($"get Session  {n}\t {a}");

        }


        public IActionResult SetCookie()
        {
            CookieOptions options=new CookieOptions();
            options.Expires= DateTime.Now.AddDays(1);

            //session Cookie(expiration session)
            HttpContext.Response.Cookies.Append("Name", "Ahmed");
            //Presestent Cookie(expire date)
            HttpContext.Response.Cookies.Append("Age", "25",options);
            
            //logic
            return Content("Cookie Save");
        }


        public IActionResult GetCookie() //at any controller
        {
            //logic
            string n= HttpContext.Request.Cookies["Name"];
            string a= HttpContext.Request.Cookies["Age"];

            return Content($"Cookie = {n} \t {a}");
        }
    }
}
