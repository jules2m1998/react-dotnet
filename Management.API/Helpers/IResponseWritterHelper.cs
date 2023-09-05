using Management.Api.Responses;

namespace Management.Api.Helpers;

public interface IResponseWritterHelper
{
    Task WriteAsync(HttpResponse response, ErrorResponses error);
}
