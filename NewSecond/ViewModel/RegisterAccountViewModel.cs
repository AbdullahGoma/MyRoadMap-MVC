﻿using System.ComponentModel.DataAnnotations;

namespace NewSecond.ViewModel
{
    public class RegisterAccountViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm not Matched")]
        public string ConfirmPassword { get; set; }
    }
}
