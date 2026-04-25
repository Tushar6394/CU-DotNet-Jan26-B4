namespace InsureTrust.API.Common;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
    public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();
    public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;

    public static ApiResponse<T> Ok(T data, string message = "Request completed successfully.") => new()
    {
        Success = true,
        Message = message,
        Data = data
    };

    public static ApiResponse<T> Fail(string message, params string[] errors) => new()
    {
        Success = false,
        Message = message,
        Errors = errors
    };
}
