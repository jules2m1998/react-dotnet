using Management.Api.Responses;

namespace Management.Api.Helpers;

public interface IResponseWritterHelper
{
    Task WriteAsync(Microsoft.AspNetCore.Http.HttpResponse response, ErrorResponses error);
}
