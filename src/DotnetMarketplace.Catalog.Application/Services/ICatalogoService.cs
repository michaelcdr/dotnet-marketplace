using DotnetMarketplace.Catalog.Application.ViewModels;

namespace DotnetMarketplace.Catalog.Application.Services
{
    public interface ICatalogoService : IDisposable
    {
        Task<List<HighlightCategoryViewModel>> GetCategories();
    }
}
