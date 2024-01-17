using DotnetMarketplace.Catalog.Application.ViewModels;
using DotnetMarketplace.Catalog.Domain.Entities;
using DotnetMarketplace.Catalog.Domain.Repositories;

namespace DotnetMarketplace.Catalog.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CatalogService(ICategoryRepository categoryRepository,
                              IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
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
                    Image = $"/img/categories/{(category.Image ?? string.Empty)}",
                    Title = category.Title,
                });
            }

            return categoriesViewModel;
        }

        public async Task<List<CategoryItemMenu>> GetCategoriesNavMenu()
        {
            List<Category> categories = await _categoryRepository.GetCategories();

            var categoriesViewModel = new List<CategoryItemMenu>();

            foreach (var category in categories)
            {
                categoriesViewModel.Add(new CategoryItemMenu
                {
                    Id = category.Id.ToString(), 
                    Title = category.Title,
                });
            }

            return categoriesViewModel;
        }

        public async Task<ProductsOnSaleViewModel> GetProductsOnSales()
        {
            List<Product> products = await _productRepository.GetAllOnSale();

            return new ProductsOnSaleViewModel
            {
                ProductsOnSales = products.Select(e => new ProductOnSaleModel
                {
                    ProductId = e.Id.ToString(),
                    Description = e.Description,
                    Image = e.Images.First().FileName,
                    Price = e.Price.ToString("C")

                }).ToList()
            };
        }

        public void Dispose()
        {

        }
    }
}
