using Microsoft.AspNetCore.ResponseCompression;
using System.Globalization;

namespace Management.Api.Configs;

public static class StaticFilesConfigExtension
{
    public static IApplicationBuilder EnableStaticFiles(this IApplicationBuilder @this)
    {
        @this.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                // Cache static files for 30 days
                ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=2592000");
                ctx.Context.Response.Headers.Append("Expires",
                    DateTime.UtcNow.AddDays(30).ToString("R", CultureInfo.InvariantCulture));
                ctx.Context.Response.Headers["Access-Control-Allow-Origin"] = "*";
            }
        });
        return @this;
    }

    public static IServiceCollection AddCompression(this IServiceCollection @this)
    {
        @this.AddResponseCompression(opt =>
        {
            opt.EnableForHttps = true;
            opt.Providers.Add<BrotliCompressionProvider>();
            opt.Providers.Add<GzipCompressionProvider>();
        });

        @this.Configure<BrotliCompressionProviderOptions>(opt =>
        {
            opt.Level = System.IO.Compression.CompressionLevel.Fastest;
        });

        @this.Configure<GzipCompressionProviderOptions>(opt =>
        {
            opt.Level = System.IO.Compression.CompressionLevel.SmallestSize;
        });

        return @this;
    }
}
