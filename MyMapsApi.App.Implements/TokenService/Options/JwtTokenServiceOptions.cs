namespace MyMapsApi.App.Implements.TokenService.Options;

/// <summary>
/// Класс для настройки JwtTokenService
/// </summary>
public record class JwtTokenServiceOptions
{
    /// <summary>
    /// Кто выпустил jwt-токен
    /// </summary>
    public required string Issuer { get; set; }
    /// <summary>
    /// Секретный ключ для генерации access-токена
    /// </summary>
    public required string SecretKey { get; set; }
    /// <summary>
    /// Время жизни access-токена
    /// </summary>
    public required double Lifetime { get; set; }
}