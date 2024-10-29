using System.ComponentModel.DataAnnotations;
using System.Web.Mvc; // Для работы с HtmlHelper
using ChatAura.Models; // Для доступа к вашим моделям


namespace ChatAura.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }
    }
}
