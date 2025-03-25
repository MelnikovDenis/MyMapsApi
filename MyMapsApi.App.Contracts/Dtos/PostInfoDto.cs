namespace MyMapsApi.App.Contracts.Dtos;

/// <summary>
/// Объект передачи данных с информацие о посте
/// </summary>
public class PostInfoDto
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
}
