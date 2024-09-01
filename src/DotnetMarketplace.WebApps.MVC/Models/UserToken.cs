namespace DotnetMarketplace.WebApps.MVC.Models;

public class UserToken
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public IList<UserClaim> Claims { get; set; } = new List<UserClaim>();
}
