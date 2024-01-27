using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NewSecond.Models
{
    // This Case in Database first, when classes generated auto
    [ModelMetadataType(typeof(StudentMetaData))]
    public partial class Student
    {

    }
    public class StudentMetaData
    {
        public int Id { get; set; }
        [Display(Name = "Student Name"), Required(ErrorMessage = "Name Is Required")]
        [RegularExpression(pattern: "^[a-zA-Z]{3,}$", ErrorMessage = "Name must be char only and more than 2 chars")]
        [Remote(action: "NameExist", controller: "Student", ErrorMessage = "Name is Already Exist"
            , AdditionalFields = "Id")] // Client Side Validation(add scripts)
        public string Name { get; set; } // TextChange <input asp-for="name" value
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Display(Name = "Student Image")]
        [Required]
        [RegularExpression(@"\w+\.(jpg|png)", ErrorMessage = "Image Must Contains only Jpg or Png Extentions")]
        public string Img { get; set; }
        [Range(minimum: 20, maximum: 30)]
        [AgeDivBy5(info = 5)]
        public int Age { get; set; }
        public int DepartmentID { get; set; }
    }
}
