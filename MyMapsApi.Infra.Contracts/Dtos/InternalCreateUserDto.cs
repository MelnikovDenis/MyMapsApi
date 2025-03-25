namespace MyMapsApi.Infra.Contracts.Dtos;

/// <summary>
/// Объект передачи данных о пользователе
/// </summary>
public record class InternalCreateUserDto
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Хэш пароля пользователя
    /// </summary>
    public required string PasswordHash { get; set; }
}