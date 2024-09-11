using Microsoft.AspNetCore.Mvc;
using MKT.API.Core.Controllers;
using MKT.ContentManager.API.Models;
using MKT.ContentManager.Domain.Repositories;

namespace DotnetMarketplace.Auth.API.Controllers;

[Route("api/carousel")]
public class CarouselController : MainApiController
{
    private readonly ICarouselRepository _carouselRepository;

    public CarouselController(ICarouselRepository carouselRepository)
    {
        _carouselRepository = carouselRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var carouselItens = await _carouselRepository.ObterTodos();

        var itens = new List<CarouselDTO>();

        foreach (var item in carouselItens)
            itens.Add(new CarouselDTO($"/img/carousel/{item.FileName}"));

        return CustomResponse(itens);
    }
}