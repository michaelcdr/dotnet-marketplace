using DotnetMarketplace.Auth.API.Models;
using DotnetMarketplace.Auth.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.Auth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gera um token para usar na autenticação da API
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Logar")]
        public async Task<IActionResult> Logar(UserLogin model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var response = await _userService.Login(model);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar(UserRegister model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var response = await _userService.Register(model);

            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }
    }

}

