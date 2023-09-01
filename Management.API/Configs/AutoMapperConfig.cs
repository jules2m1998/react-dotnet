using Managerment.Core.Business;

namespace Management.API.Configs;

public static class AutoMapperConfig
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        return services;
    }
}
