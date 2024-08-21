using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Postcrossing.Domain.Authentication;
using Postcrossing.Domain.UseCase;
using Postcrossing.Domain.UseCase.CreateUser;

namespace Postcrossing.Domain.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPostcrossingDomain(this IServiceCollection service)
    {
        service.AddSingleton<IIdentityProvider, IdentityProvider>();

        service
            .AddScoped<ICreateUserUseCase, CreateUserUseCase>();

        service.AddValidatorsFromAssemblyContaining<CreateUserCommand>();

        return service;
    }
}