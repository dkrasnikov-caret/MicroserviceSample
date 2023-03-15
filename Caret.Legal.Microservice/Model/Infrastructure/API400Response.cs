using System.Text.Json.Serialization;

namespace Caret.Legal.Microservice.Model.Infrastructure;

/// <summary>
///   400 error response.
/// </summary>
public class Api400Response
{
  /// <summary>
  ///   Gets or sets the type.
  /// </summary>
  /// <value>
  ///   The type.
  /// </value>
  [JsonPropertyName("code")]
  public int Code { get; set; }

  /// <summary>
  ///   Gets or sets the message.
  /// </summary>
  /// <value>
  ///   The message.
  /// </value>
  [JsonPropertyName("message")]
  public string? Message { get; set; }
}
