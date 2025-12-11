namespace CvAlInstante.API.Middleware;

public class ErrorResponse
{
    public string Message { get; set; }
    public string? Details { get; set; }

    public ErrorResponse(string message, string? details = null)
    {
        Message = message;
        Details = details;
    }
}
