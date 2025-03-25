namespace MyMapsApi.Core.Entities;

/// <summary>
/// Пост
/// </summary>
public class Post
{
    /// <summary>
    /// Уникальный идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Долгота
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Широта
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public required string Commentary { get; set; }

    /// <summary>
    /// Имя пользователя, создавшего пост
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Пользователь, создавший пост
    /// </summary>
    public required User User { get; set; }
}
