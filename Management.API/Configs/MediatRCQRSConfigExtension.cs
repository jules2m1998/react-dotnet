using Management.Core.Business;

namespace Management.Api.Configs;

public static class MediatRCQRSConfigExtension
{
    public static IServiceCollection ConfigureMediatR(this IServiceCollection @this)
    {
        @this.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(EmptyEntry).Assembly));

        return @this;
    }
}
