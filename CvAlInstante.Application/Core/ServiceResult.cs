namespace CvAlInstante.Application.Core;

public class ServiceResult<T>
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public T? Data { get; init; }

    public static ServiceResult<T> Ok(T data, string message = "") =>
        new() { Success = true, Data = data, Message = message };

    public static ServiceResult<T> Fail(string message) =>
        new() { Success = false, Message = message };
}
