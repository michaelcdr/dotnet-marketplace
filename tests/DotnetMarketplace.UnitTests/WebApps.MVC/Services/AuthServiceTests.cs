using DotnetMarketplace.WebApps.MVC.Services;
using Microsoft.AspNetCore.Http;
using MKT.Core.Services;
using Moq;

namespace DotnetMarketplace.UnitTests.WebApps.MVC.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<HttpClient> _mockHttpClientFactory;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAcessor;
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly AuthHttpService _authService;
        private readonly Mock<ServiceBase> _mockServiceBase;
        private readonly Mock<ISerializerService> _mockSerializerService;

        public AuthServiceTests()
        {
            _mockHttpClientFactory = new Mock<HttpClient>();
            _mockHttpContextAcessor = new Mock<IHttpContextAccessor>();
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            _mockSerializerService = new Mock<ISerializerService>();

            var mockHttpClient = new Mock<HttpClient>(_mockHttpMessageHandler.Object);
            //_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(mockHttpClient.Object);

            var mockContextAcessor = new Mock<HttpContextAccessor>(_mockHttpContextAcessor.Object);
            //_mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(mockHttpClient.Object);

            //_authService = new AuthService(
            //    _mockHttpClientFactory.Object, 
            //    _mockHttpContextAcessor.Object,
            //    _mockSerializerService.Object,

            //);

            _mockServiceBase = new Mock<ServiceBase>();
        }

        //[Fact]
        //public async Task Login_Sucesso_DeveRetornarTokenGeneratedResponse()
        //{
        //    // Arrange
        //    var loginModel = new UserLogin { UserName = "test", Password = "password" };
        //    var expectedResponse = new TokenGeneratedResponse { AccessToken = "token123" , ResponseResult = null };

        //    _mockHttpMessageHandler
        //        .Protected()
        //        .Setup<Task<HttpResponseMessage>>(
        //            "SendAsync",
        //            ItExpr.IsAny<HttpRequestMessage>(),
        //            ItExpr.IsAny<CancellationToken>()
        //        )
        //        .ReturnsAsync(new HttpResponseMessage
        //        {
        //            StatusCode = System.Net.HttpStatusCode.OK,
        //            Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
        //        });

        //    //service base 
        //    var mockHttpResponseMessage = new HttpResponseMessage
        //    {
        //        StatusCode = System.Net.HttpStatusCode.OK,
        //        Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
        //    };

        //    _mockServiceBase
        //        .Protected()
        //        .Setup<bool>("HandleResponseErrors", ItExpr.IsAny<HttpResponseMessage>())
        //        .Returns(true);

        //    _mockSerializerService
        //       .Setup(x => x.Deserialize<TokenGeneratedResponse>(It.IsAny<HttpResponseMessage>()))
        //       .ReturnsAsync(expectedResponse);


        //    // Act
        //    var result = await _authService.Login(loginModel);

        //    // Assert
        //    Assert.NotNull(result);

        //    Assert.Null(result.ResponseResult);
        //}

        //[Fact]
        //public async Task Login_Erro_DeveRetornarResponseResult()
        //{
        //    // Arrange
        //    var loginModel = new UserLogin { UserName = "test", Password = "wrong" };
        //    var errorResponse = new ResponseResult { Message = "Invalid credentials" };

        //    _mockHttpMessageHandler
        //        .Protected()
        //        .Setup<Task<HttpResponseMessage>>(
        //            "SendAsync",
        //            ItExpr.IsAny<HttpRequestMessage>(),
        //            ItExpr.IsAny<CancellationToken>()
        //        )
        //        .ReturnsAsync(new HttpResponseMessage
        //        {
        //            StatusCode = System.Net.HttpStatusCode.Unauthorized,
        //            Content = new StringContent(JsonSerializer.Serialize(errorResponse))
        //        });

        //    // Act & Assert
        //    var result = await _authService.Login(loginModel);
        //    Assert.NotNull(result.ResponseResult);
        //    Assert.Equal(errorResponse.Message, result.ResponseResult.Message);
        //}

        //[Fact]
        //public async Task Login_Nulo_DeveLancarInvalidOperationException()
        //{
        //    // Arrange
        //    var loginModel = new UserLogin { UserName = "test", Password = "password" };

        //    _mockHttpMessageHandler
        //        .Protected()
        //        .Setup<Task<HttpResponseMessage>>(
        //            "SendAsync",
        //            ItExpr.IsAny<HttpRequestMessage>(),
        //            ItExpr.IsAny<CancellationToken>()
        //        )
        //        .ReturnsAsync(new HttpResponseMessage
        //        {
        //            StatusCode = System.Net.HttpStatusCode.OK,
        //            Content = new StringContent("")
        //        });

        //    // Act & Assert
        //    await Assert.ThrowsAsync<InvalidOperationException>(() => _authService.Login(loginModel));
        //}
    }
}
