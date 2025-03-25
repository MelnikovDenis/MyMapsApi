using MyMapsApi.Core.Models;
using System.Text.Json;

namespace MyMapsApi.WebHost.Middlewares;

/// <summary>
/// Кастомный middleware глобальной обработки ошибок
/// </summary>
/// <param name="next">Делегат для следующего middleware в конвейере обработки запроса/param>
public class CustomExceptionHandler(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    /// <summary>
    /// Вызываемый middleware метод, где будет происходить отлавливание ошибок
    /// </summary>
    /// <param name="context">Http контекст запрсоа</param>
    /// <param name="logger">Логгер</param>
    /// <returns>Асинхронная задача</returns>
    public async Task Invoke(HttpContext context, ILogger<CustomExceptionHandler> logger)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionMessageAsync(context, ex, logger).ConfigureAwait(false);
        }
    }
    private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception, ILogger<CustomExceptionHandler> logger)
    {
        var statusCode = 500;
        logger.LogError(exception.Message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(JsonSerializer.Serialize(new OperationResult<string>(exception.Message, statusCode)));
    }
}
