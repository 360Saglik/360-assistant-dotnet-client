using Assistant.Enums;

namespace Assistant.Commons;

public static class Helpers
{
    public static string GetServerUrl(ServerType serverType)
    {
        return serverType switch
        {
            ServerType.Development => "https://integration-api-gateway.360saglik.dev/",
            ServerType.Production => "https://integration-api-gateway.360saglik.com/",
            _ => "https://integration-api-gateway.360saglik.dev/"
        };
    }
}