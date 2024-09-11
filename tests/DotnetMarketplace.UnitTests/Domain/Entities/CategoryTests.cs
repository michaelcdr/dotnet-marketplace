using MKT.Catalog.Domain.Entities;
using MKT.Core.DomainObjects;

namespace DotnetMarketplace.UnitTests.Catalog.Domain.Entities
{
    public class CategoryTests
    {
        [Theory]
        [InlineData("", "imagem001.jpg")]
        [InlineData("Category 01", "")]
        public void Category_Validate_ValidationShouldNotThrowDomainExceptions(string titulo, string imagem)
        {
            Assert.Throws<DomainException>(
                () =>
                {
                    var category = new Category(titulo, imagem);
                }
            );
        }
    }
}
