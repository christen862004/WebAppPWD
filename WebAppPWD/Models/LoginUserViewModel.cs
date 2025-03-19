using System.ComponentModel.DataAnnotations;

namespace WebAppPWD.Models
{
    public class LoginUserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
