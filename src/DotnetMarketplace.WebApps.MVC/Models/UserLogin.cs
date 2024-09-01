using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotnetMarketplace.WebApps.MVC.Models;

public class UserLogin
{
    [Required(ErrorMessage = "Informe o {0}")]
    [Display(Name = "Usuário")]
    public string? UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    [Display(Name = "Senha")]
    public string? Password { get; set; } = string.Empty;
}