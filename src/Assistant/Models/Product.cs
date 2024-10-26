using System.Text.Json.Serialization;

namespace Assistant.Models;

/// <summary>
///     Represents a product in the assistants app.
/// </summary>
public class Product
{
    /// <summary>
    ///     Unique identifier for the product.
    /// </summary>
    /// <example>12345</example>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    ///     Number of remaining session rights available for the product.
    /// </summary>
    /// <example>10</example>
    [JsonPropertyName("remainingSessionRights")]
    public int RemainingSessionRights { get; set; }
}