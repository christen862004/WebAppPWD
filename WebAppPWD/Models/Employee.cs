using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPWD.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="*")]
        [MaxLength(20,ErrorMessage ="Name Must be less than 20 char")]
        [MinLength(3)]
        [Unique]
        public string Name { get; set; }
        
        public string? Address { get; set; }

        //[Range(6000,50000)]  
        [Remote("CheckSalary","Employee",AdditionalFields = "DepartmentId")]
        public int Salary { get; set; }
        
        [Display(Name="Profile Image")]
        [RegularExpression(@"\w+\.(png|jpg)",ErrorMessage ="Image must be png or jpg ex: imag1.jpg")]
        public string? ImageURL { get; set; }
        
        public string? JobTitle { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public virtual Department? Department { get; set; }

    }
}
