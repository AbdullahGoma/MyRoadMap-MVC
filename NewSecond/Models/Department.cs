using System.ComponentModel.DataAnnotations;

namespace NewSecond.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Display(Name = "Department Name")]
        //[DataType(DataType.EmailAddress)]
        public string Name { get; set; }
        public string ManagerName { get; set; }
        // There is no Lazy Loading in EFcore
        public ICollection<Student> Students { get; set; }
    }
}