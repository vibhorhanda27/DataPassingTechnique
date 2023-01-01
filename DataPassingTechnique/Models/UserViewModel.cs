using DataPassingTechnique.Helper;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DataPassingTechnique.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Please enter 1 Uppercase, 1 Number, 1 Special Char, and 1 Lowercase Char & Min Length (8 Chars)")]

        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password is required")]
        [Compare("Password",ErrorMessage ="Compare Password  do not match with Password")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"^[89][0-9]{9}",ErrorMessage ="Please Enter Phone number in correct format")]
        public string? ContactNumber { get; set; }

        [ValidateCheckBox(ErrorMessage ="Please accept Terms and conditions")]
        public bool Terms { get; set; }
        
    }
}
