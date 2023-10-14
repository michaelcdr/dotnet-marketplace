namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; } = string.Empty;
    }
}