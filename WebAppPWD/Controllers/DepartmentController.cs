using Microsoft.AspNetCore.Mvc;
using WebAppPWD.Models;
using WebAppPWD.Repository;

namespace WebAppPWD.Controllers
{
    //Statesless
    public class DepartmentController : Controller
    {
       // ITIContext context = new ITIContext();

        IDepartmentRespoitory departmentRepository;
        IEmployeeRepository employeeRepository;

        public DepartmentController(IEmployeeRepository empRepo, IDepartmentRespoitory deptRepo)
        {
            departmentRepository=deptRepo;//= new DepartmentRepository();
            employeeRepository=empRepo;//= new EmployeeRepository();
        }

        public IActionResult Index()//not numerl function
        {

            List<Department> departmentList = departmentRepository.GetAll();
            return View("Index",departmentList);//Index ,Model List<department>
        }

        #region Ajax Call action Return Jsno
        public IActionResult DeptEmpDetails()
        {
            List<Department> deptList= departmentRepository.GetAll();
            return View("DeptEmpDetails", deptList);
        }
        //Department/GetEmpByDeptID?deptid=1
        public IActionResult GetEmpByDeptID(int deptid)
        {
            var employees = employeeRepository.GetByDeptID(deptid)
                .Select(e => new {e.Id,e.Name}).ToList();
            return Json(employees);
        }

        #endregion
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
                departmentRepository.Insert(deptReqquest);
                departmentRepository.Save();           
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
            Department dept = departmentRepository.GetById(id);
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
