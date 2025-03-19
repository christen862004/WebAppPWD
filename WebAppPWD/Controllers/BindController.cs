using Microsoft.AspNetCore.Mvc;
using WebAppPWD.Filtters;
using WebAppPWD.Models;

namespace WebAppPWD.Controllers
{
    

    public class BindController : Controller
    {
        //prmitive int ,string ..
        //Bind/testPrimitive?name=Ahmed&age=12
        //Bind/testPrimitive?name=Ahmed
        //Bind/testPrimitive?age=0
        //Bind/testPrimitive?age=10&name=ahme&id=10
        //Bind/testPrimitive/12?age=10&name=ahmeid=
        //Class/Method/id
        /*
         <form method="get" action="Bind/testPrimitive" >
        <input name="name">
        <input name="age">
        </form>
         
         */

        public IActionResult testPrimitive(int id,int age,string name,string[] color)
        {  
            return Content("ok");
        }

        //Test Collection
        //Bind/TestDic?name=christen&phoneBook[ahmed]=777777&phoneBook[Beshoy]=88888
        public IActionResult TestDic(Dictionary<string,string>phoneBook ,string name)
        {
            return Content("ok");

        }


        //Bind Complex (Class)
        //Bind/TestObj/1?name=SD&ManagerName=Ahmed&Employees[0].Name=Sara
        public IActionResult TestObj(Department dept)
        //public IActionResult TestObj(int Id, string Name, string ManagerName, List<Employee> Employees)
        {

            return Content("ok");

        }
    }
}
