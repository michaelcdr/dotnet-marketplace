namespace DotnetMarketplace.WebApps.MVC.Models;

public class NavViewModel
{
    public int QtdItensCarrinho { get; set; }
    public bool TaLogado { get; set; }
    public string UrlPerfil { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string TipoUsuario { get; set; }
    public List<CategoryItemMenu> Categories { get; set; }

    public NavViewModel()
    {
        Categories = new List<CategoryItemMenu>();
    }
}
