using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Postcrossing.Storage.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddStorage(this IServiceCollection service, string dataBaseStringConnection)
    {
        service.AddDbContext<PostcrossingDbContext>(option => option.UseNpgsql(dataBaseStringConnection));

        return service;
    }
}