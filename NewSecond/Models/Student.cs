using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewSecond.Models
{
    public partial class Student
    {
        public int ID { get; set; }
        public string Name { get; set; } 
        public string Address { get; set; }
        public string Img { get; set; }
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }
    }
}
