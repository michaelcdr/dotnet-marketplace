using DotnetMarketplace.Catalog.Domain.Entities;
using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Tests
{
    public class ProductTests
    {
        [Theory]
        [InlineData("", "Lorem ipsum dolor", 100, 1, "michael")]
        [InlineData("Produto 01", "", 100, 1, "michael")]
        [InlineData("Produto 01", "Lorem ipsum dolor", 0, 1, "michael")]
        [InlineData("Produto 01", "Lorem ipsum dolor", -100, 1, "michael")]
        [InlineData("Produto 01", "Lorem ipsum dolor", 100, -10, "michael")]
        [InlineData("Produto 01", "Lorem ipsum dolor", 100, 10, "")]
        public void Product_Validate_ValidationShouldNotThrowDomainExceptions(string titulo,
                                                                              string descricao,
                                                                              decimal price,
                                                                              int stock,
                                                                              string createdBy)
        {
            Assert.Throws<DomainException>(
                () =>  {
                    var p = new Product(titulo, descricao, price, createdBy, true, stock, "1000", Guid.NewGuid().ToString(), Guid.NewGuid());
                }
            ); 
        }
    }
}