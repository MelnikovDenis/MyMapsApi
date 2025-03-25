namespace MyMapsApi.Core.Entities;

/// <summary>
/// Пользователь
/// </summary>
public class User
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Хэш пароля пользователя
    /// </summary>
    public required string PasswordHash { get; set; }

    /// <summary>
    /// Посты пользователя
    /// </summary>
    public required List<Post> Posts { get; set; }
}