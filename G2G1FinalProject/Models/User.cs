using System.ComponentModel.DataAnnotations;

namespace G2G1FinalProject.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter Your Full Name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Email Address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Locked")]
        public bool isLocked { get; set; }

        [Display(Name = "Admin")]
        public bool isAdmin { get; set; }
    }
}
