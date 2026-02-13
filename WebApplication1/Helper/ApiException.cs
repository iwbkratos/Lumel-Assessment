namespace WebApplication1.Helper
{
    public class ApiException(int statusCode, string message, string? details) : Exception
    {
        public int StatusCode { get; set; } = statusCode;
        public string Message { get; set; } = message;
        public string? Details { get; set; } = details;
    }
}
