using System.Text.Json;
using Assistant.Commons;

namespace Assistant.Response;

public class ApiResponse : BaseResponse
{
    public ApiDataResponse? Data { get; set; }

    public object[]? Actions { get; set; }

    public string? Message { get; set; }

    public static ApiResponse FromJson(string json, int statusCode, bool isSuccess)
    {
        var response = JsonSerializer.Deserialize<ApiResponse>(json, SerializerOptions.Options) ?? new ApiResponse();
        response.StatusCode = statusCode;
        response.IsSuccess = isSuccess;
        if (isSuccess) return response;

        response.Error = response.Error;
        response.Message ??= "An unexpected error occurred.";
        return response;
    }
}