using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace NewSecond.Models
{
    public class AgeDivBy5Attribute : ValidationAttribute
    {
        public int info { get; set; } = 5;
        // Server Side Only
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Student student = validationContext.ObjectInstance as Student;

            int age = int.Parse(value.ToString());
            if(age % info == 0)
            {
                // Success
                return ValidationResult.Success; //true
            }
            // Failed => Default Message Error
            return new ValidationResult("Age Must be Divided By 5");
        }
    }
}
