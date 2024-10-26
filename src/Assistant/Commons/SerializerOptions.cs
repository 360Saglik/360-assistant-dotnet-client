using System.Text.Json;
using System.Text.Json.Serialization;

namespace Assistant.Commons;

public static class SerializerOptions
{
    public static JsonSerializerOptions? Options => new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
}