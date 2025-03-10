using Microsoft.AspNetCore.Mvc;
using WebAppPWD.Models;
using WebAppPWD.ViewModel;

namespace WebAppPWD.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Details(int id)
        {
            string msg = "Hello";
            int temp = 28;
            List<string> brches=new List<string>() { "Assiut","Alex","Menia","Cario"};
            string color = "red";
            ViewData["msg"] = "Hello";
            ViewData["Temp"] = temp;
            ViewData["CLR"] = color;
            ViewData["Brch"] = brches;
            ViewBag.Age = 10;
            ViewBag.CLR = "Blue";


            Employee EmpModel= context.Employees.FirstOrDefault(e => e.Id == id);
            return View("Details",EmpModel); //View 'Details' ,Model Employee
        }


        public IActionResult DetailsWithVM(int id)
        {
            //collect data from different source
            string msg = "Hello";
            int temp = 28;
            List<string> brches = new List<string>() { "Assiut", "Alex", "Menia", "Cario" };
            string color = "red";
            Employee EmpModel = context.Employees.FirstOrDefault(e => e.Id == id);
            //declare object from ViewModel
            EmployeeWurhMsgTempBrchListClrViewModel empViewModel = 
                new EmployeeWurhMsgTempBrchListClrViewModel();

            //Mapping FRom Model to ViewModel (automapper)
            empViewModel.EmpName = EmpModel.Name;
            empViewModel.EmpID = EmpModel.Id;
            empViewModel.Msg = msg;
            empViewModel.Branches = brches;
            empViewModel.Color = "red";
            empViewModel.Temp =28;

            //return view
            return View("DetailsWithVM", empViewModel);
            //View : DetailsWithVM ,Model EmployeeWurhMsgTempBrchListClrViewModel
        }
    }
}
