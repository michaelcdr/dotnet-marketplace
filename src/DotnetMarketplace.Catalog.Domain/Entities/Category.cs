using MKT.Core.DomainObjects;

namespace MKT.Catalog.Domain.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public ICollection<SubCategory>? SubCategories { get; set; } = new HashSet<SubCategory>();

        protected Category() { }

        public Category(string title, string image)
        {
            Title = title;
            Image = image;

            Validate();
        }

        public void AddSubCategory(string subCategory)
        {
            this?.SubCategories?.Add(
                new SubCategory(
                    subCategory,
                    this
                )
            );
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Title)) throw new DomainException("Informe o titulo");

            if (string.IsNullOrEmpty(Image)) throw new DomainException("Informe a imagem");
        }

        public override string ToString() { return $"ID: {Id}, {Title}"; }
    }
}