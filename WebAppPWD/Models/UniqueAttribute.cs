using System.ComponentModel.DataAnnotations;

namespace WebAppPWD.Models
{
    public class UniqueAttribute:ValidationAttribute
    {

        public int xyz { get; set; }


        //custom vakdation (server side only)
        //work with mvc  web api
        ITIContext context = new ITIContext();
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string empName = value.ToString();

            Employee EmpFromRequest = (Employee)validationContext.ObjectInstance;



            Employee EmpFromDatabase=
                context.Employees
                .FirstOrDefault(e => e.Name == empName && e.DepartmentId==EmpFromRequest.DepartmentId);

            if (EmpFromDatabase == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Exist :(");
        }
    }
}
