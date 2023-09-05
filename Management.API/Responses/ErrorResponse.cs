using System.Text.Json;

namespace Management.Api.Responses;

public class ErrorResponses
{
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public string Detail { get; set; } = string.Empty;
    public Dictionary<string, string[]>? Details { get; set; } = null;
}
