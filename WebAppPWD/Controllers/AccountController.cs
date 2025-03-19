using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppPWD.Models;
using WebAppPWD.ViewModel;

namespace WebAppPWD.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userFromREquest)
        {
            if (ModelState.IsValid)
            {
                //add db
                ApplicationUser userApp = new ApplicationUser();
                userApp.UserName = userFromREquest.UserName;
                userApp.PasswordHash = userFromREquest.Password;
                userApp.Address = userFromREquest.Address;
                IdentityResult result=await userManager.CreateAsync(userApp,userFromREquest.Password);
                if (result.Succeeded)
                { 
                    //add user to role
                    await userManager.AddToRoleAsync(userApp, "Admin");//add User To Role
                    await signInManager.SignInAsync(userApp, false); 
                    //cookkie
                    return RedirectToAction("Index", "Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register",userFromREquest);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userFRomREquest)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appFromDb=
                    await userManager.FindByNameAsync(userFRomREquest.UserName);
                if (appFromDb != null)
                {
                    bool found= await userManager.CheckPasswordAsync(appFromDb, userFRomREquest.Password);
                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("Address", appFromDb.Address));

                        await signInManager.SignInWithClaimsAsync(appFromDb, userFRomREquest.RememberMe,claims);
                        //await signInManager.SignInAsync(appFromDb, userFRomREquest.RememberMe);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login",userFRomREquest);
        }


        #endregion

        public async Task<IActionResult> Logout()
        {
           await  signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
