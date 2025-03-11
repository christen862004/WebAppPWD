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
        public IActionResult Index()//not numerl function
        {
            List<Department> departmentList = context.Departments.ToList();
            return View("Index",departmentList);//Index ,Model List<department>
        }
        #region Add
        //action can handel any request get | post
        public IActionResult New()
        {
            return View("New");//Model null
        }


        //Department/SaveNew? Name = &ManagerName =
        [HttpPost]
        public IActionResult SaveNew(Department deptReqquest)//string Name,string ManagerName)
        {
            /*
            //if (Request.Method == "POST")
            //{
            //}
            //return NotFound();            
            */
            if (deptReqquest.Name != null)
            {//0
                context.Departments.Add(deptReqquest);
                context.SaveChanges();//identity              
                return RedirectToAction("Index", "Department");
            }
            return View("New", deptReqquest);//
            //View NEw ,Model =DEpartment
            
        }

        #endregion

        #region Details
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
        #endregion

        #region OverLoad
        [HttpGet]
        public IActionResult Method1()
        {
            return Content("M1 Get");
        }

        [HttpPost]
        public IActionResult Method1(string str)
        {
            return Content("M1_1 post");
        }
        #endregion

    }
}
