using Core;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IMongoDbSettings,MongoDbSettings>();
        return services;
    }
}
