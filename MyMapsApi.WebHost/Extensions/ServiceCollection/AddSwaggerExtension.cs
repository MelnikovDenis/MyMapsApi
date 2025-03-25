using Microsoft.OpenApi.Models;

namespace MyMapsApi.WebHost.Extensions.ServiceCollection;

public static class AddSwaggerExtension
{
    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerGen(options =>
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, $"MyMapsApi.Controllers.xml");

            options.IncludeXmlComments(filePath);

            // Добавляем Bearer-аутентификацию
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization заголовок. Пример: \"Authorization: Bearer {token}\"",
                Name = "Authorization", // Название заголовка
                In = ParameterLocation.Header, // Где находится токен (в заголовке)
                Type = SecuritySchemeType.Http, // Тип схемы (HTTP)
                Scheme = "bearer", // Схема (bearer)
                BearerFormat = "JWT" // Формат токена (JWT)
            });

            // Добавляем требование аутентификации для всех эндпоинтов
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>() // Список scope (пустой, если не используется)
                }
            });
        });
    }
}