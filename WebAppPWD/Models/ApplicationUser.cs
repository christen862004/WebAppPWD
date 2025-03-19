using Microsoft.AspNetCore.Identity;

namespace WebAppPWD.Models
{
    //ocP
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
