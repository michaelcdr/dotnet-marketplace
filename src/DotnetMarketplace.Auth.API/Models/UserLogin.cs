using System.ComponentModel.DataAnnotations;

namespace DotnetMarketplace.Auth.API.Models;

public class UserLogin
{
    [Required(ErrorMessage = "Informe o {0}")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    public string Password { get; set; } = string.Empty;
}