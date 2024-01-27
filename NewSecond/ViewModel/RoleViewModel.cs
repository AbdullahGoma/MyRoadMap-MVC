using System.ComponentModel.DataAnnotations;

namespace NewSecond.ViewModel
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
