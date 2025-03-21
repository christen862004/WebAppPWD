﻿using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using WebAppPWD.Models;
using WebAppPWD.Repository;
using WebAppPWD.ViewModel;

namespace WebAppPWD.Controllers
{
    public class EmployeeController : Controller
    {
        //DIP
        IEmployeeRepository EmployeeRepository;
        IDepartmentRespoitory DepartmentRepository;//=new DepartmentRepository();
        //Injection DI
        public EmployeeController(IDepartmentRespoitory depRepo,IEmployeeRepository empRepo)
        {
            // EmployeeRepository = new EmployeeRepository();
            // DepartmentRepository = new DepartmentRepository();
            EmployeeRepository = empRepo;
            DepartmentRepository = depRepo;
        }


        public IActionResult Index()
        {
            List<Employee> empsList = EmployeeRepository.GetAll();
            return View("Index", empsList);//Model List<Employee>
        }

        #region action return Partial

        //Employee/GetEmpCard/1
        public IActionResult GetEmpCard(int id)
        {
            Employee emp = EmployeeRepository.GetById(id);
            return PartialView("_EmpCard",emp);//Model null
        }


        #endregion


        //Employee/CheckSalary?Salary=50000&DepartmentId=10
        public IActionResult CheckSalary(int Salary, int DepartmentId)
       {
            
            if (DepartmentId == 1)
            {
                if (Salary > 6000)
                    return Json(true);
            }else if (DepartmentId == 2)
            {
                if (Salary > 10000)
                    return Json(true);
            } 
        
            return Json(false);
        }

        #region Add
        public IActionResult New()
        {
            ViewData["deptList"] = DepartmentRepository.GetAll();
            return View("New");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//check token internal request (int ,register)
        //handl only internal requet
        public IActionResult SaveNew(Employee empFromRequest) {
           
           if(ModelState.IsValid==true)
            {
                try
                {
                    EmployeeRepository.Insert(empFromRequest);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index");
                }catch(Exception ex)
                {
                    //send exceptio as erro r view
                    //ModelState.AddModelError("DepartmentId",ex.InnerException.Message);
                    ModelState.AddModelError(string.Empty,ex.InnerException.Message);
                }
            }
           
            ViewData["deptList"] = DepartmentRepository.GetAll();
            return View("New", empFromRequest);//go To View with name "NEw"  Model with type Employee

        }


        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            //Get Data
            Employee EmpModel= EmployeeRepository.GetById(id);
            List<Department> DeptList=DepartmentRepository.GetAll();

            //DEcalre ViewModl
            EmpWithDEptListViewModel empVM =   new EmpWithDEptListViewModel();

            //Map from source to destination(VM)
            empVM.Id = EmpModel.Id;
            empVM.Name = EmpModel.Name;
            empVM.Salary = EmpModel.Salary;
            empVM.ImageURL = EmpModel.ImageURL;
            empVM.Address = EmpModel.Address;
            empVM.JobTitle = EmpModel.JobTitle;
            empVM.DepartmentId = EmpModel.DepartmentId;
            empVM.DepartmentList = DeptList;

            //return View("Edit", empVM);//Model Null ,VM
            return View(empVM);//Model Null ,VM
        }
        [HttpPost]
        public IActionResult SaveEdit(EmpWithDEptListViewModel empFromReq)
        {
            if(empFromReq.Name!=null && empFromReq.Salary > 6000)
            {
                //get old ref
                Employee empFromDB=EmployeeRepository.GetById(empFromReq.Id);
                //change value
                empFromDB.Name=empFromReq.Name;
                empFromDB.Address=empFromReq.Address;
                empFromDB.Salary=empFromReq.Salary;
                empFromDB.DepartmentId = empFromReq.DepartmentId;
                empFromDB.JobTitle=empFromReq.JobTitle;
                empFromDB.ImageURL=empFromReq.ImageURL;
                //save Cah
                EmployeeRepository.Save();
                return RedirectToAction("Index");
            }
            empFromReq.DepartmentList = DepartmentRepository.GetAll();

            return View("Edit", empFromReq);
        }

        #endregion

        #region Details
        public IActionResult Details(int id,string name)
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


            Employee EmpModel = EmployeeRepository.GetById(id);//context.Employees.FirstOrDefault(e => e.Id == id);
            return View("Details",EmpModel); //View 'Details' ,Model Employee
        }

        public IActionResult DetailsWithVM(int id)
        {
            //collect data from different source
            string msg = "Hello";
            int temp = 28;
            List<string> brches = new List<string>() { "Assiut", "Alex", "Menia", "Cario" };
            string color = "red";
            Employee EmpModel = EmployeeRepository.GetById(id);//context.Employees.FirstOrDefault(e => e.Id == id);
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
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            Employee emp = EmployeeRepository.GetById(id);
            return View(emp);//view with the same action name ("Delete",emp)
        }
        #endregion


    }
}
