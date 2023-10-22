﻿using DotnetMarketplace.Core.DomainObjects;

namespace DotnetMarketplace.Catalog.Domain.Entities
{
    public class ProductsComments : Entity
    {
        protected ProductsComments() { }

        public ProductsComments(Guid productId, 
                                Product product, 
                                string title, 
                                string description, 
                                bool recommend, 
                                string ratting)
        { 
            ProductId = productId;
            Product = product;
            Title = title;
            Description = description;
            Recommend = recommend;
            Ratting = ratting;
        }

        public Guid ProductId { get; private set; }
        public Product Product { get; private set; } 
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool Recommend { get; private set; }
        public string Ratting { get; private set; } = string.Empty;
    }
}