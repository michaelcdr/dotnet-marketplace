using System.ComponentModel.DataAnnotations;

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

public class UserRegister
{
    [Required(ErrorMessage = "Informe o {0}")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a {0}")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
    public string Email { get; set; } = string.Empty;
}

public class TokenGeneratedResponse
{
    public string AccessToken { get; set; } = string.Empty;
    public double ExpiresIn { get; set; }
    public UserToken UserToken { get; set; }
}

public class UserToken
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public IList<UserClaim> Claims { get; set; } = new List<UserClaim>();
}

public class UserClaim
{
    public string? Type { get; set; }
    public string? Value { get; set; }
}
 
public class UserLoginResult
{
    public List<UserClaim> Claims { get; set; }
}

