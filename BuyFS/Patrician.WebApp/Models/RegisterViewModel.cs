using System.ComponentModel.DataAnnotations;


namespace Patrician.WebApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="User Name field is mandatory.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Please enter an e-mail address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid e-mail address.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Password field is mandatory.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your password twice.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
