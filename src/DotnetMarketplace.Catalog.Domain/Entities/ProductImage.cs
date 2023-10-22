namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public string FileName { get; set; } = string.Empty;
    }
}