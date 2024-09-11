namespace MKT.Catalog.API.Models
{
    public class ProductsOnSaleViewModel
    {
        public List<ProductOnSaleModel> ProductsOnSales { get; set; } = new List<ProductOnSaleModel>();

        /// <summary>
        /// Product on sale, based on last buyed products.
        /// </summary>
        public List<ProductOnSaleModel> ProductsOnSaleBasedOnLastBuyedProducts { get; set; } = new List<ProductOnSaleModel>();
    }
}
