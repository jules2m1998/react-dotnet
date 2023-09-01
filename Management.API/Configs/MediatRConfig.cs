using Managerment.Core.Business;

namespace Management.API.Configs;

public static class MediatRConfig
{
    public static IServiceCollection ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(EmptyEntry).Assembly);
        });

        return services;
    }
}
