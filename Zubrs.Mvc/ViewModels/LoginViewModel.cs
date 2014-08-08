using System.ComponentModel.DataAnnotations;

namespace Zubrs.Mvc.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        public string Password { get; set; }
    }
}