namespace MKT.Catalog.API.Models
{
    public class ProductOnSaleModel
    {
        public string ProductId { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
