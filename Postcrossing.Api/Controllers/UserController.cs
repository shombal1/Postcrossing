using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postcrossing.Domain.Authentication;
using Postcrossing.Storage;
using Postcrossing.Storage.Models;

namespace Postcrossing.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("AddUser")]
    public async Task<IActionResult> AddUser(CancellationToken cancellationToken)
    {
        return await Task.FromResult(Ok("ok"));
    }
    
    
    [HttpPost]
    [Route("SetUser")]
    public async Task<IActionResult> SetUser(
        [FromServices] PostcrossingDbContext dbContext,
        [FromServices] IIdentityProvider identityProvider,
        [FromBody] Guid id,
        CancellationToken cancellationToken)
    {
        UserEntity? user = await dbContext.Users.FirstOrDefaultAsync(u=>u.Id==id,cancellationToken);

        if (user is null)
        {
            return Ok("User not found");
        }
        
        identityProvider.Current = new User() { Id = id };
        
        return Ok(user);
    }
}