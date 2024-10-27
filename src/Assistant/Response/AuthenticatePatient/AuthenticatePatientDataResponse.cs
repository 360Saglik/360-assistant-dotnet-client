namespace Assistant.Response;

public class AuthenticatePatientDataResponse
{
    public string? AccessToken { get; set; }

    public DateTime? AccessTokenExpiredTime { get; set; }

    public string? RedirectUrl { get; set; }
}