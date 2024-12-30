using System.ComponentModel.DataAnnotations;

namespace DotnetMarketplace.WebApps.MVC.Models.Admin;

public class CreateProductViewModel
{
    [Display(Name = "Titulo")]
    [StringLength(100, ErrorMessage = "Limite de 100 caracteres")]
    [Required(ErrorMessage = "Informe o campo {0}")]
    public string? Titulo { get; set; }

    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "Informe o campo {0}")]
    public string? Sku { get; set; }

    [Display(Name = "Estoque")]
    [Required(ErrorMessage = "Informe o campo {0}")]
    public int Estoque { get; set; }

    public Guid VendedorId { get; set; }

    public bool OnSale { get; set; }

    [Display(Name = "Preço à Vista")]
    [Required(ErrorMessage = "Informe o campo {0}")]
    public decimal? PrecoAVista { get; set; }

    [Display(Name = "Descritivo")]
    [Required(ErrorMessage = "Informe o campo {0}")]
    public string? Descritivo { get; set; }

    [Display(Name = "Categoria")]
    [Required(ErrorMessage = "Informe o campo {0}")]
    public int? CategoriaId { get; set; }

    [Display(Name = "SubCategoria")]
    [Required(ErrorMessage = "Informe o campo {0}")]
    public int? SubCategoriaId { get; set; }

    public List<IFormFile>? Imagens { get; set; }

    public List<KeyValuePair<string,string>> Categories { get; set; }

    public CreateProductViewModel()
    {

    }
}