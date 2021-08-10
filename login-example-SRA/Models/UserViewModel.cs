using System;
using System.ComponentModel.DataAnnotations;

namespace login_example_SRA.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // [Display(Name = "Confirm Email Address")]
        // [Compare("Email", ErrorMessage = "Email and Confirm Email must match.")]
        // public string ConfirmEmail { get; set; }
        
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "You need to provide a password 8-100 characters long.")]
        public string Password { get; set; }

        // [Display(Name = "Confirm Password")]
        // [Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]
        // public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; } = 0;
        
        // [Display(Name = "Robot")]
        // public bool IsRobot { get; set; } = true;
    }
}