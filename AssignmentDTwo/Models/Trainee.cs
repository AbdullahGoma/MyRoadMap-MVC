using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AssignmentDTwo.Models
{
    public class Trainee
    {
        //[Key]
        //[ForeignKey("IdentityUser")]
        //public string ID { get; set; }
        public int ID { get; set; }
        [Column("FullName")]
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string? Img { get; set; }
        public string Address { get; set; }
        public float Grade { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<CourseResult> CourseResults { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        //public IdentityUser IdentityUser { get; set; }
    }
}
