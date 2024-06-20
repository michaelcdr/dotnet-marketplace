using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace DotnetMarketplace.Auth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        public AuthController(ILogger<WeatherForecastController> logger)
        {
            
        }

        [Route("autenticar")]
        public async Task Autenticar()
        {

        }

        [Route("registrar")]
        public async Task Registrar()
        {

        }
    }

}
