using System.Text.Json;
using Assistant.Enums;
using Assistant.Response;

namespace Assistant.Commons;

public static class Helpers
{
    /// <summary>
    ///     Get server url by server type
    /// </summary>
    /// <param name="serverType">Default: Development</param>
    /// <returns>Development or Production Api Url</returns>
    public static string GetServerUrl(ServerType serverType)
    {
        return serverType switch
        {
            ServerType.Development => "https://integration-api-gateway.360saglik.dev/",
            ServerType.Production => "https://integration-api-gateway.360saglik.com/",
            _ => "https://integration-api-gateway.360saglik.dev/"
        };
    }

    /// <summary>
    ///     Deserialize json to object
    /// </summary>
    /// <param name="json"></param>
    /// <param name="statusCode"></param>
    /// <param name="isSuccess"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T FromJsonToObject<T>(string json, int statusCode, bool isSuccess) where T : ApiResponse, new()
    {
        var response = JsonSerializer.Deserialize<T>(json, SerializerOptions.Options) ?? new T();
        response.StatusCode = statusCode;
        response.IsSuccess = isSuccess;
        if (!isSuccess) response.Message ??= "An unexpected error occurred.";
        return response;
    }
}