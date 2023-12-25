

using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services) 
    {
        var assembly = typeof(ServiceRegistration).Assembly;
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);
        });
        return services;
    }
}
