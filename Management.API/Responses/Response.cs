namespace Management.Api.Responses;

public class Response<T> where T : class
{
    public bool Success { get; set; } = default;
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public Response(bool success, string message, T? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }
}
