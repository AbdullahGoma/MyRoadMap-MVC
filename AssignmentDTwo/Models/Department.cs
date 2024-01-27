using AssignmentDTwo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDTwo.Models
{
    [Table("Department", Schema = "HR")] // To Set Name Table in Database, and Set Schema to HR 
    public class Department
    {
        public int ID { get; set; }
        [Required] // To Set it to not allow null
        [MaxLength(100)]
        public string Name { get; set; }
        public string Location { get; set; }

        // The base to connect tables to each other is Navigation properties

        //[InverseProperty("Department")]
        public ICollection<Instructor> Instructors { get; set; }
        //[InverseProperty("SupervisedDepartment")]
        //public ICollection<Instructor> Supervisors { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Trainee> Trainees { get; set; }

    }
}
