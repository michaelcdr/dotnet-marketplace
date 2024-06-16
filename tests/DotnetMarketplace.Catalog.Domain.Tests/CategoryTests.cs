using DotnetMarketplace.Catalog.Domain.Entities;
using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Tests
{
    public class CategoryTests
    {
        [Theory]
        [InlineData("", "imagem001.jpg")]
        [InlineData("Category 01", "")]
        public void Category_Validate_ValidationShouldNotThrowDomainExceptions(string titulo,string imagem)
        {
            Assert.Throws<DomainException>(
                () => {
                    var category = new Category(titulo, imagem);
                }
            );
        }
    }
}