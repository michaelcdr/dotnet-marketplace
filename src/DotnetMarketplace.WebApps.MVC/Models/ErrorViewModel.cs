namespace DotnetMarketplace.WebApps.MVC.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
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

    public class HomeOffersViewModel 
    {
    
    } 
}