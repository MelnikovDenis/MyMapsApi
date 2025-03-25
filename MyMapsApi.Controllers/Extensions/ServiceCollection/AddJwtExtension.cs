using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyMapsApi.Controllers.Extensions.ServiceCollection;

/// <summary>
/// Класс-контейнер для AddJwt
/// </summary>
public static class AddJwtExtension
{
    /// <summary>
    /// Добавить сервисы для обработки jwt
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    /// <param name="config">Конфигурация</param>
    /// <exception cref="ArgumentNullException">Если не задан SecretKey в appsettings</exception>
    public static void AddJwt(this IServiceCollection services, IConfiguration config)
    {
        var secretKey = config.GetValue<string>("JwtTokenServiceOptions:SecretKey")
            ?? throw new ArgumentNullException("В файле конфигурации нет секции JwtTokenServiceOptions:SecretKey");

        var issuer = config.GetValue<string>("JwtTokenServiceOptions:Issuer")
            ?? throw new ArgumentNullException("В файле конфигурации нет секции JwtTokenServiceOptions:Issuer");

        // Добавляем аутентификацию JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, // валидируем подпись
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), // задаем ключ для подписи
                    ValidIssuer = issuer, // валидный issuer
                    ValidateIssuer = true, // валидируем issuer
                    ValidateAudience = false, // не валидируем audience
                    ClockSkew = TimeSpan.Zero // смещение часового пояса
                };
            });
    }
}