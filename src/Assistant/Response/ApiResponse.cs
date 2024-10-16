namespace Assistant.Response;

public class ApiResponse
{
    public ApiDataResponse Data { get; set; }

    public object[] Actions { get; set; }

    public string Message { get; set; }
}