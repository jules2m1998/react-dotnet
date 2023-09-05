using Management.Api.Helpers;
using Management.Api.Middlewares;
using Management.Core.Domain.Exceptions;

namespace Management.Api.Configs;

public static class ExceptionHandlerExtension
{
    public static IApplicationBuilder UseHttpExceptionHandler(this IApplicationBuilder @this)
    {
        HttpExceptionMapper mapper = new();


        mapper.Map<NotFoundException>(StatusCodes.Status404NotFound);


        var helper = new ResponseWritterHelper();
        @this.UseMiddleware<HandleExceptionMiddleware>(mapper, helper);
        return @this;
    }
}
