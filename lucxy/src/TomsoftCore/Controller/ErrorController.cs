namespace Lucxy.LucxyCore.Controller;

using Microsoft.AspNetCore.Mvc;

[ApiController]
public class ErrorController : ControllerBase
{
    [Route("404")]
    public IActionResult PageNotFound()
    {
        return Ok("Error 404: Page not found");
    }
}
