using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppPWD.Models;

namespace WebAppPWD.Controllers
{
    /*
     Catch Request
        1) end with Controller (HomeController)
        2) Inherit Class Contoller

     */
 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /*
         * Method Insdie Contoller call Action
         * 1) Must Public 
         * 2) Cant Be Static
         * 3) Cant Be Overload (in only in one case)
         */
        //public string testMsg()
        //{   
        //    return "Hello";
        //}
        //home/testtExt
        public ContentResult testText()
        {
            //logic.............
            //DEclare
            ContentResult result = new ContentResult();
            //set dtat
            result.Content = "Hello";
            //return
            return result;
        }
        //action View
        //home/testView
        public ViewResult testView()
        {
            return View("View1");
        }

        //no=>odd content | no==>even View
        //class/method?no=1  ==Content
        //class/method?no=20  ==Content
        public IActionResult testMix(int no)
        {
            if(no%2==0)
            {
                //logic
                return View("View1");
            }
            else
            {
                return Content("Hello");
            }
        }

        //dry
        //home/view?ViewNAme=view1 endpoint
        //[NonAction]
        //public ViewResult View(string ViewNAme)
        //{
        //    ViewResult result = new ViewResult();
        //    result.ViewName = ViewNAme;
        //    return result;
        //}





        /*
         * type of action return
         * string     ==> ContentResult  ==> Content()
         * view       ==> ViewResult     ==> View()
         * json       ==> JsonREsult     ==> Json()
         * file       ==>
         * notFound   ==> NotFoundREsult ==> NotFount()
         * unauthorit ...
         * Empty
         * ....
         */
        #region Org Method
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 1000, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int id)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
