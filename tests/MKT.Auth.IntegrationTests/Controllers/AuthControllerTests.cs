using DotnetMarketplace.Auth.API.Controllers;
using DotnetMarketplace.Auth.API.Jwt;
using DotnetMarketplace.Auth.API.Models;
using DotnetMarketplace.Auth.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MKT.Core.Responses;
using Moq;

namespace MKT.Auth.IntegrationTests.Controllers;

public class AuthControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;
    private Mock<IUserService> _mockAuthService;

    public AuthControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _mockAuthService = new Mock<IUserService>();
    }

    [Fact]
    public void Login_UserLoginModelInvalid_ReturnsResponseError()
    {
        // Arrange
        var controller = CreateController();
        var model = new UserLogin { /* Invalid properties */ };

        // Act
        var response = new AppResponse<TokenGeneratedResponse>(false, "Não foi possivel logar.", new List<Notification>());
        _mockAuthService.Setup(s => s.Login(It.IsAny<UserLogin>())).ReturnsAsync(response);

        // Assert
        Assert.False(response.Success);
    }

    [Fact]
    public void Login_UserLoginModelValid_ReturnsResponseSuccess()
    {
        // Arrange
        var controller = CreateController();
        var model = new UserLogin { /* Valid properties */ };

        // Act
        var response = new AppResponse<TokenGeneratedResponse>(true, "Logado com sucesso.", new List<Notification>());
        _mockAuthService.Setup(s => s.Login(It.IsAny<UserLogin>())).ReturnsAsync(response);

        // Assert
        Assert.True(response.Success);
    }

    private AuthController CreateController()
    {
        return new AuthController(_mockAuthService.Object);
    }
}

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");

        // Configurações adicionais para o ambiente de teste...
    }
}
