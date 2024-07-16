using Microsoft.AspNetCore.Mvc;

namespace DotnetMarketplace.Core.Controllers;

[ApiController]
public abstract class MainApiController : ControllerBase
{
    protected ICollection<string> Errors = [];

    protected ActionResult CustomResponse(object? result = null)
    {
        if (OperationIsValid())  return Ok(result);

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Mensagens", Errors.ToArray() }
        }));
    }
    
    protected bool OperationIsValid() 
    {
        return !Errors.Any();
    }

    protected void AddError(string err)
    {
        Errors.Add(err);
    }

    protected void CleanErrors()
    {
        Errors.Clear();
    }
}