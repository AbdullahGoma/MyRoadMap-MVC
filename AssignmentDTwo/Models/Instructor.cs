using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDTwo.Models
{
    public partial class Instructor
    {
        //[Key]
        //[ForeignKey("IdentityUser")]
        //public string ID { get; set; }
        public int ID { get; set; }
        [Column("FullName")]
        public string Name { get; set; }
        public string Img { get; set; }
        public double? Salary { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }

        // The base to connect tables to each other is Navigation properties
        public int DepartmentID { get; set; }
        public Department? Department { get; set; } // In Run Time do Lazy Loading

        //public int? SupervisedDepartmentID { get; set; }
        //public Department SupervisedDepartment { get; set; }
        public Account? Account { get; set; }
        public ICollection<WorksFor>? WorksFors { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        //public IdentityUser IdentityUser { get; set; }
    }
}
