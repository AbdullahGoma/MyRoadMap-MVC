using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssignmentDTwo.Models
{
    // This Case in Database first, when classes generated auto
    [ModelMetadataType(typeof(InstructorMetaData))]
    public partial class Instructor
    {

    }
    public class InstructorMetaData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Display(Name = "Instructor Name"), Required(ErrorMessage = "Name Is Required")]
        [RegularExpression(pattern: "^[a-zA-Z]{3,}$", ErrorMessage = "Name must be char only and more than 2 chars")]
        [Remote(action: "NameExist", controller: "Instructor", ErrorMessage = "Name is Already Exist",
            AdditionalFields = "ID")] // Client Side Validation(add scripts)
        public string Name { get; set; }
        [Display(Name = "Instructor Image")]
        [Required]
        [RegularExpression(@"\w+\.(jpg|png)", ErrorMessage = "Image Must Contains only Jpg or Png Extentions")]
        public string Img { get; set; }
        public double? Salary { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? Birthdate { get; set; }

        // The base to connect tables to each other is Navigation properties
        public int DepartmentID { get; set; }
    }
}
