namespace MyMapsApi.App.Infra.Contracts.Dtos;

/// <summary>
/// Объект передачи данных для создания поста
/// </summary>
public record class InternalCreatePostDto
{

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
