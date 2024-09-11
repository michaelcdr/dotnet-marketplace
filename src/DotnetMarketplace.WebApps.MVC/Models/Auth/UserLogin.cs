using System.ComponentModel.DataAnnotations;

namespace DotnetMarketplace.WebApps.MVC.Models.Auth;

public class UserLogin
{
    [Required(ErrorMessage = "Informe o {0}")]
    [Display(Name = "Usuário")]
    public string? UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    [Display(Name = "Senha")]
    public string? Password { get; set; } = string.Empty;
}