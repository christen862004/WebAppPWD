using Microsoft.AspNetCore.Mvc;
using WebAppPWD.Models;

namespace WebAppPWD.Controllers
{
    public class StudentController : Controller
    {


        StudentBL StudentBL=new StudentBL();
        //Student/all
        public IActionResult All()
        {
            List<Student> stdListModel =StudentBL.GetAll();
            //send view
            return View("ShowAll",stdListModel);
            //view ShowAll ,Model with Type "List<Student>"
        }
    }
}
