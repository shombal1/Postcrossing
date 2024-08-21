using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postcrossing.Api.Models;
using Postcrossing.Domain.Authentication;
using Postcrossing.Domain.UseCase.CreateUser;
using Postcrossing.Storage;
using Postcrossing.Storage.Models;

namespace Postcrossing.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("AddUser")]
    public async Task<IActionResult> AddUser(
        [FromServices] ICreateUserUseCase useCase,
        [FromBody] UserDto userDto,
        CancellationToken cancellationToken)
    {
        return Ok(await useCase.Execute(
            new CreateUserCommand(userDto.FistName, userDto.LastName,
                new CreateResidentialAddressCommand(userDto.AddressDto.CountryName, userDto.AddressDto.DistrictName,
                    userDto.AddressDto.CityName)), cancellationToken));
    }


    [HttpPost]
    [Route("SetUser")]
    public async Task<IActionResult> SetUser(
        [FromServices] PostcrossingDbContext dbContext,
        [FromServices] IIdentityProvider identityProvider,
        [FromBody] Guid id,
        CancellationToken cancellationToken)
    {
        UserEntity? user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    
        if (user is null)
        {
            return Ok("User not found");
        }

        identityProvider.Current = new Domain.Authentication.User() { Id = id };
    
        return Ok(user);
    }
}