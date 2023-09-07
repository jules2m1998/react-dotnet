using Management.Api.Helpers;
using Management.Api.Responses;
using Management.Core.Domain.Exceptions;

namespace Management.Api.Middlewares;

public class HttpExceptionMapper
{
    public IDictionary<Type, int> Mapper { get; private set; } = new Dictionary<Type, int>();

    public HttpExceptionMapper Map<TException>(int statusCode) where TException : BaseException
    {
        Mapper.Add(typeof(TException), statusCode);
        return this;
    }
}

public class HandleExceptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly HttpExceptionMapper httpMapper;
    private readonly IResponseWritterHelper helper;

    public HandleExceptionMiddleware(RequestDelegate next, HttpExceptionMapper httpMapper, IResponseWritterHelper helper)
    {
        this.next = next;
        this.httpMapper = httpMapper;
        this.helper = helper;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }catch (BaseException ex)
        {
            var mapper = httpMapper.Mapper;

            var error = new ErrorResponses
            {
                Title = "Internal server error",
                Status = StatusCodes.Status500InternalServerError,
                Detail = "An unexpected error occured ont the server.",
                Details = null
            };
            if (mapper.TryGetValue(ex.GetType(), out var code))
                error = new ErrorResponses
                {
                    Title = ex.Title,
                    Status = code,
                    Detail = ex.Message,
                    Details = ex.Errors
                };

            context.Response.StatusCode = error.Status;
            context.Response.ContentType = "application/json";
            await helper.WriteAsync(context.Response, error);
        }
    }
}
