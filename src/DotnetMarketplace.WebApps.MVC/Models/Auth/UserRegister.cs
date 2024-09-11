using System.ComponentModel.DataAnnotations;

namespace DotnetMarketplace.WebApps.MVC.Models.Auth;

public class UserRegister
{
    [Required(ErrorMessage = "Informe o {0}")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    public string PasswordConfirm { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
    public string Email { get; set; } = string.Empty;
}
