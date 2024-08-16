using Microsoft.AspNetCore.Mvc;

namespace Postcrossing.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExamController : ControllerBase
{
    [HttpGet]
    [Route("All")]
    public Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Task.FromResult<IActionResult>(Ok( "string"));
    }
}