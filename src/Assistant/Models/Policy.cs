using System.Text.Json.Serialization;

namespace Assistant.Models;

/// <summary>
///     Represents a policy in the assistants app.
/// </summary>
public class Policy
{
    /// <summary>
    ///     Unique identifier for the policy.
    /// </summary>
    /// <example>987654321</example>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    ///     Policy number assigned by the insurance provider.
    /// </summary>
    /// <example>POL123456</example>
    [JsonPropertyName("policyNumber")]
    public string PolicyNumber { get; set; }

    /// <summary>
    ///     Start date of the policy coverage period.
    /// </summary>
    /// <example>2023-01-01</example>
    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; set; }

    /// <summary>
    ///     End date of the policy coverage period.
    /// </summary>
    /// <example>2024-01-01</example>
    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; set; }

    /// <summary>
    ///     Custom Fields.
    /// </summary>
    [JsonPropertyName("group")]
    public string? Group { get; set; }

    /// <summary>
    ///     Detailed description of the policy.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     List of products covered by the policy.
    /// </summary>
    /// <example>[{ "id": "1", "remainingSessionRights": 10 }]</example>
    [JsonPropertyName("products")]
    public IList<Product>? Products { get; set; }
}