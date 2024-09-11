namespace DotnetMarketplace.WebApps.MVC.Models.Catalog;

public class CategoryViewModel
{
    public string Id { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public List<SubCategoryViewModel> SubCategories { get; set; } = new List<SubCategoryViewModel>();
}