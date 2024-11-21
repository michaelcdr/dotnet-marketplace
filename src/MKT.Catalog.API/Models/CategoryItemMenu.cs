namespace MKT.Catalog.API.Models
{
    public class CategoryItemMenu
    {
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<SubCategoryItemMenu> SubCategories { get; set; } = [];
    }

    public class SubCategoryItemMenu
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}