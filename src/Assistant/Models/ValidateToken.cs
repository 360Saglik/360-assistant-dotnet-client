using System.Text.Json.Serialization;

namespace Assistant.Models;

/// <summary>
///     Represents a token to be validated.
/// </summary>
public class ValidateToken
{
    /// <summary>
    ///     The token to be validated was obtained from Authenticate Endpoint.
    /// </summary>
    [JsonPropertyName("token")]
    public string Token { get; set; }
}