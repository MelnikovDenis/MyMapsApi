using System.ComponentModel.DataAnnotations;

namespace MyMapsApi.App.Contracts.Dtos;

/// <summary>
/// Объект передачи данных для логина
/// </summary>
public record class LoginOrRegisterDto
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Required, MinLength(1)]
    public required string Name { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    [Required, MinLength(6)]
    public required string Password { get; set; }
}
