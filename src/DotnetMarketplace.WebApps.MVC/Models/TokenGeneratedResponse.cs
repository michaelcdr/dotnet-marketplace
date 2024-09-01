using DotnetMarketplace.Core.Communication;

namespace DotnetMarketplace.WebApps.MVC.Models;

public class TokenGeneratedResponse
{
    public string AccessToken { get; set; } 
    public string RefreshToken { get; set; }
    public double ExpiresIn { get; set; }
    public UserToken UserToken { get; set; }
    public ResponseResult ResponseResult { get; set; }
}
