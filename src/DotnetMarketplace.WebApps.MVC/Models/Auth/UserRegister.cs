using System.ComponentModel.DataAnnotations;

namespace DotnetMarketplace.WebApps.MVC.Models.Auth;

public class UserRegister
{
    [Required(ErrorMessage = "Informe o login")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a senha")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a confimação da senha")]
    public string PasswordConfirm { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o sobrenome")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o e-mail")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
    public string Email { get; set; } = string.Empty;
}
