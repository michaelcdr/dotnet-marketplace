namespace DotnetMarketplace.Catalog.Application.ViewModels
{
    public class HighlightCategoryViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }

    public class NavViewModel
    {
        public int QtdItensCarrinho { get; set; }
        public bool TaLogado { get; set; }
        public string UrlPerfil { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string TipoUsuario { get; set; }
        public List<CategoryItemMenu> Categories { get; set; }
        //@*<?php
        //                     if ($_SESSION["role"] == "vendedor") {
        //                     $urlPerfil = "/admin/vendedor/editar?id=" . $_SESSION["sellerId"];
        //                     } else {
        //                     $urlPerfil = "/admin/usuario/editar?id=" . $_SESSION["userId"];
        //                     }
        //                     ?>*@
        public NavViewModel()
        {
            Categories = new List<CategoryItemMenu>();
        }
    }

    public class CategoryItemMenu
    {
        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
    }

    public class CarouselItemViewModel
    {
        public string File { get; set; }
    }

    public class ProductsOnSaleViewModel
    {
        public List<ProductOnSaleModel> ProductsOnSales { get; set; } = new List<ProductOnSaleModel>();

        /// <summary>
        /// Product on sale, based on last buyed products.
        /// </summary>
        public List<ProductOnSaleModel> ProductsOnSaleBasedOnLastBuyedProducts { get; set; } = new List<ProductOnSaleModel>();
    }

    public class ProductOnSaleModel
    {
        public string ProductId { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class CategoryViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public List<SubCategoryViewModel> SubCategories { get; set; } = new List<SubCategoryViewModel>();
    }

    public class SubCategoryViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
    }
}
