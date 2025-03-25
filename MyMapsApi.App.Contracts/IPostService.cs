using MyMapsApi.App.Contracts.Dtos;
using MyMapsApi.Core.Entities;
using MyMapsApi.Core.Models;

namespace MyMapsApi.App.Contracts;

/// <summary>
/// Интерфейс репозитория для работы с постами
/// </summary>
public interface IPostService
{
    /// <summary>
    /// Создать пост
    /// </summary>
    /// <param name="createPostDto">Объект передачи данных для создания поста</param>
    /// <param name="name">Имя пользователя, создавшего пост</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Результат операции с созданным постом</returns>
    public Task<OperationResult<PostInfoDto>> CreateAsync(CreatePostDto createPostDto, string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить все посты
    /// </summary>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Результат операции со списком всех постов</returns>
    public Task<OperationResult<IEnumerable<PostInfoDto>>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить пост
    /// </summary>
    /// <param name="postId">Id поста</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Асинхронная задача</returns>
    public Task DeleteAsync(Guid postId, CancellationToken cancellationToken = default);
}