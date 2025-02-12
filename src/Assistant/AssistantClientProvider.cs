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
    private readonly string _baseUrl;

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
        _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
        _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
        _baseUrl = Helpers.GetServerUrl(serverType);
    }

    public async Task<AuthenticatePatientResponse> AuthenticatePatientAsync(Patient patient)
    {
        ArgumentNullException.ThrowIfNull(patient);
        
        return await SendRequestAsync<Patient, AuthenticatePatientResponse>(
            patient, 
            "auth/join"
        ).ConfigureAwait(false);
    }

    public async Task<ValidateTokenResponse?> ValidateTokenAsync(ValidateToken token)
    {
        ArgumentNullException.ThrowIfNull(token);
        
        return await SendRequestAsync<ValidateToken, ValidateTokenResponse>(
            token, 
            "auth/validate"
        ).ConfigureAwait(false);
    }

    private async Task<TResponse> SendRequestAsync<TRequest, TResponse>(TRequest model, string endpoint) where TResponse : ApiResponse, new()
    {
        var request = CreateRequest(Path.Combine(_baseUrl, endpoint), model);

        try
        {
            using var response = await Client.SendAsync(request).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return Helpers.FromJsonToObject<TResponse>(
                responseContent, 
                (int)response.StatusCode,
                response.IsSuccessStatusCode
            );
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"HTTP request failed while processing {endpoint}", ex);
        }
        catch (TaskCanceledException ex)
        {
            throw new Exception($"Request timeout while processing {endpoint}", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"An unexpected error occurred while processing {endpoint}", ex);
        }
    }

    private HttpRequestMessage CreateRequest<T>(string requestUri, T model)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
        request.Headers.Add("client-id", _clientId);
        request.Headers.Add("secret-key", _clientSecret);

        var serializedModel = JsonSerializer.Serialize(model, SerializerOptions.Options);
        request.Content = new StringContent(serializedModel, Encoding.UTF8, "application/json");

        return request;
    }
}