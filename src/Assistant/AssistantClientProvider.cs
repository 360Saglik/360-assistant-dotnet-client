using System.Net;
using System.Text;
using System.Text.Json;
using Assistant.Commons;
using Assistant.Enums;
using Assistant.Models;
using Assistant.Response;
using Assistant.Response.ValidateToken;

namespace Assistant;

public class AssistantClientProvider
{
    private static readonly HttpClient Client;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly ServerType _serverType;

    static AssistantClientProvider()
    {
#if !NETSTANDARD1_3
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
#endif
        var handler = new HttpClientHandler { AllowAutoRedirect = false };
        Client = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(20)
        };
    }

    public AssistantClientProvider(string clientId, string clientSecret, ServerType serverType = ServerType.Development)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _serverType = serverType;
    }

    public async Task<AuthenticatePatientResponse> AuthenticatePatient(Patient patient)
    {
        var requestUri = Helpers.GetServerUrl(_serverType) + "auth/join";
        var request = CreateRequest(requestUri, patient);

        try
        {
            var response = await Client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            return Helpers.FromJsonToObject<AuthenticatePatientResponse>(responseContent, (int)response.StatusCode,
                response.IsSuccessStatusCode);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while authenticating.", ex);
        }
    }

    public async Task<ValidateTokenResponse?> ValidateToken(ValidateToken token)
    {
        var requestUri = Helpers.GetServerUrl(_serverType) + "auth/validate";
        var request = CreateRequest(requestUri, token);

        try
        {
            var response = await Client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            return Helpers.FromJsonToObject<ValidateTokenResponse>(responseContent, (int)response.StatusCode,
                response.IsSuccessStatusCode);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while authenticating.", ex);
        }
    }

    private HttpRequestMessage CreateRequest<T>(string requestUri, T model)
    {
        var request = CreateRequestMessage(requestUri);

        var serializedModel = JsonSerializer.Serialize(model, SerializerOptions.Options);
        var content = new StringContent(serializedModel, Encoding.UTF8, "application/json");
        request.Content = content;

        return request;
    }

    private HttpRequestMessage CreateRequestMessage(string requestUri)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
        request.Headers.Add("client-id", _clientId);
        request.Headers.Add("secret-key", _clientSecret);
        return request;
    }
}