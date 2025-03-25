﻿using MyMapsApi.Core.Entities;
using MyMapsApi.Core.Models;
using MyMapsApi.Infra.Contracts.Dtos;

namespace MyMapsApi.Infra.Contracts;

/// <summary>
/// Интерфейс репозитория для работы с постами
/// </summary>
public interface IPostRepository
{
    /// <summary>
    /// Получить все посты
    /// </summary>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Результат операции со списком всех постов</returns>
    public Task<OperationResult<IEnumerable<Post>>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Создать пост
    /// </summary>
    /// <param name="createPostDto">Объект передачи данных для создания поста</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Результат операции с созданным постом</returns>
    public Task<OperationResult<Post>> CreateAsync(InternalCreatePostDto createPostDto, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить пост
    /// </summary>
    /// <param name="postId">Id поста</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Асинхронная задача</returns>
    public Task DeleteAsync(Guid postId, CancellationToken cancellationToken = default);
}