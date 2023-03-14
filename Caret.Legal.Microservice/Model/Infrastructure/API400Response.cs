using System.Text.Json.Serialization;

namespace Caret.Legal.Microservice.Model.Infrastructure;

public class Api400Response
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
