using Management.Core.Business;

namespace Management.Api.Configs;

public static class AutoMapperConfigExtension
{
    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection @this)
    {
        @this.AddAutoMapper(typeof(EmptyEntry));

        return @this;
    }
}
