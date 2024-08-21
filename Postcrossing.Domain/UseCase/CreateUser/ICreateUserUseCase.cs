using Postcrossing.Domain.Models;

namespace Postcrossing.Domain.UseCase.CreateUser;

public interface ICreateUserUseCase
{
    public Task<User> Execute(CreateUserCommand command,CancellationToken cancellationToken);
}