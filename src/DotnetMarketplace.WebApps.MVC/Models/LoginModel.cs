using System.ComponentModel.DataAnnotations;

namespace DotnetMarketplace.WebApps.MVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o {0}")]
        [Display(Name = "Usuário")]
        public string? Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a {0}")]
        public string? Password { get; set; }

        public LoginModel()
        {

        }
    }
}