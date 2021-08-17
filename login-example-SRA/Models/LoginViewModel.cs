using System;
using System.ComponentModel.DataAnnotations;

namespace login_example_SRA.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[\w ]+$", ErrorMessage = "Username field should only contain alphanumeric characters, underscores, and spaces.")]
        public string Username { get; set; }
        
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=(?:\S*\d))(?=(?:\S*[A-Za-z]))(?=\S*[^A-Za-z0-9])\S{8,}", ErrorMessage = "Password should have a minimum of 8 characters, at least 1 Uppercase Letter, 1 Lowercase Letter, 1 Number, and 1 Special Character.")]
        public string Password { get; set; }
    }
}