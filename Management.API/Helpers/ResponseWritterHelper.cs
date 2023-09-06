using Management.Api.Responses;
using System.Text.Json;

namespace Management.Api.Helpers;

public class ResponseWritterHelper : IResponseWritterHelper
{
    public async Task WriteAsync(Microsoft.AspNetCore.Http.HttpResponse response, ErrorResponses error)
    {
        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        await response.WriteAsync(JsonSerializer.Serialize(error, serializeOptions));
    }
}
