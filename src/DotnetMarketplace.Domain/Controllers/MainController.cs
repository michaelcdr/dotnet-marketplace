using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.Core.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Erros = [];

        protected ActionResult CustomResponse(object? result = null)
        {
            if (OperationIsValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() }
            }));
        }
        
        protected bool OperationIsValid() 
        {
            return !Erros.Any();
        }

        protected void AddError(string err)
        {
            Erros.Add(err);
        }

        protected void CleanErrors()
        {
            Erros.Clear();
        }
    }
}