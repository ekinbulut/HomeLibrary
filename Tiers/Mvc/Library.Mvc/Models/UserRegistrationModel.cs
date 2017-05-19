using System.ComponentModel.DataAnnotations;

namespace Library.Mvc.Models
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "Fill Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fill Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Fill Occupation")]
        public string Occupation { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Fill Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Fill Password")]
        public string RetypePassword { get; set; }

        [Required(ErrorMessage = "Fill IsAgree")]
        public bool IsAgree { get; set; }

    }
}
