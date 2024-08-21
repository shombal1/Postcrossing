using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Postcrossing.Domain.UseCase.CreateUser;
using Postcrossing.Domain.UseCase.GetExistLocation;
using Postcrossing.Storage.Storage;

namespace Postcrossing.Storage.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddStorage(this IServiceCollection service, string dataBaseStringConnection)
    {
        service.AddDbContext<PostcrossingDbContext>(option => option.UseNpgsql(dataBaseStringConnection));

        service
            .AddScoped<IGetAddressStorage, GetAddressStorage>()
            .AddScoped<ICreateUserStorage, CreateUserStorage>();
        
        return service;
    }
}