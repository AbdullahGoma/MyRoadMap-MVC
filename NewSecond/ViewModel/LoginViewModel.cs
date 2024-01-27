using System.ComponentModel.DataAnnotations;

namespace NewSecond.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool isPersiste { get; set; }
    }
}
