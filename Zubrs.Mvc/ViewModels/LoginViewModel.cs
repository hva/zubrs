using System.ComponentModel.DataAnnotations;

namespace Zubrs.Mvc.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}