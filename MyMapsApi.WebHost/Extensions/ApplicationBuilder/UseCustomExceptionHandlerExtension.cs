using MyMapsApi.WebHost.Middlewares;

namespace MyMapsApi.WebHost.Extensions.ApplicationBuilder;

/// <summary>
/// Класс-контейнер для UseCustomExceptionHandler
/// </summary>
public static class UseCustomExceptionHandlerExtension
{
    /// <summary>
    /// Зарегистрировать middleware CustomExceptionHandler
    /// </summary>
    /// <param name="app">Builder для пайплайна приложения</param>
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionHandler>();
    }
}

