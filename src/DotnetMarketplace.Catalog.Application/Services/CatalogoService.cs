using DotnetMarketplace.Catalog.Application.ViewModels;
using DotnetMarketplace.Catalog.Domain.Entities;
using DotnetMarketplace.Catalog.Domain.Repositories;

namespace DotnetMarketplace.Catalog.Application.Services
{
    public class CatalogoService : ICatalogoService
    {
        public ICategoryRepository _categoryRepository;
        public CatalogoService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<List<HighlightCategoryViewModel>> GetCategories()
        {
            List<Category> categories = await _categoryRepository.GetCategories();

            var categoriesViewModel = new List<HighlightCategoryViewModel>();

            foreach (var category in categories)
            {
                categoriesViewModel.Add(new HighlightCategoryViewModel
                {
                    Id = category.Id.ToString(),
                    Image = category.Image ?? string.Empty,
                    Title = category.Title,
                });
            }

            return categoriesViewModel;
        }
    }
}
