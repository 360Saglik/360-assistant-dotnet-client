using System.Text.Json.Serialization;

namespace Assistant.Response;

public class BaseResponse
{
    [JsonPropertyName("isSuccess")] public bool IsSuccess { get; set; }

    [JsonPropertyName("statusCode")] public int StatusCode { get; set; }

    [JsonPropertyName("error")] public string? Error { get; set; }
}