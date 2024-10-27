namespace Assistant.Response;

public class ApiResponse
{
    public object[]? Actions { get; set; }

    public string? Message { get; set; }

    public bool IsSuccess { get; set; }

    public int StatusCode { get; set; }

    public string? Error { get; set; }
}