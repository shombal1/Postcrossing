using Microsoft.Extensions.DependencyInjection;
using Postcrossing.Domain.Authentication;

namespace Postcrossing.Domain.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPostcrossingDomain(this IServiceCollection service)
    {
        service.AddSingleton<IIdentityProvider, IdentityProvider>();
        
        return service;
    }
}