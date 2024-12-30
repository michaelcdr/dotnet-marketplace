using MKT.Catalog.API.Services;
using MKT.Catalog.Domain.Entities;
using MKT.Catalog.Domain.Repositories;
using MKT.Core.Communication;

namespace MKT.Catalog.API.Models.Services;

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

    public async Task<List<HighlightCategoryViewModel>> GetHighlightCategories()
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

        foreach (Category category in categories)
        {
            categoriesViewModel.Add(new CategoryItemMenu
            {
                Id = category.Id.ToString(), 
                Title = category.Title,
                SubCategories = category.SubCategories != null 
                    ? category.SubCategories.Select(s => new SubCategoryItemMenu
                        {
                            Id = s.Id.ToString(),
                            Title = s.Title
                        }).ToList() 
                    : [] 
            });
        }

        return categoriesViewModel;
    }

    public async Task<ProductsOnSaleViewModel> GetProductsOnSales()
    {
        List<Product> products = await _productRepository.GetAllOnSale();

        return new ProductsOnSaleViewModel
        {
            ProductsOnSales = products
                .Select(e => new ProductOnSaleModel {
                    ProductId = e.Id.ToString(),
                    Description = e.Description,
                    Image = e.Images.First().FileName,
                    Price = e.Price.ToString("C")
                }).ToList()
        };
    }

    public async Task<AppResponse> SetProductsOnSale(Guid productId, string user)
    {
        Product product = await _productRepository.GetById(productId);

        if (product == null) return new AppResponse(false, "Produto não encontrado.", new List<string> { "Produto não encontrado." });

        product.SetOnSale(user);
        
        await _productRepository.UnitOfWork.Commit();

        return new AppResponse(true, "Produto atualizado com sucesso.");
    }
}
