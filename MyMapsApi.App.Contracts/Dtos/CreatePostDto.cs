using System.ComponentModel.DataAnnotations;

namespace MyMapsApi.App.Contracts.Dtos;

/// <summary>
/// Объект передачи данных для создания поста
/// </summary>
public class CreatePostDto
{
    /// <summary>
    /// Долгота
    /// </summary>
    [Required]
    public double Longitude { get; set; }

    /// <summary>
    /// Широта
    /// </summary>
    [Required]
    public double Latitude { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    [Required, MinLength(1)]
    public required string Commentary { get; set; }
}
