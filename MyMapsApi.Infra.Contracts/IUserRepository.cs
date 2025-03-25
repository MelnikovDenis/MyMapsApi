using MyMapsApi.Core.Entities;
using MyMapsApi.Core.Models;
using MyMapsApi.Infra.Contracts.Dtos;

namespace MyMapsApi.Infra.Contracts;


/// <summary>
/// Интерфейс сервиса для взаимодействия с пользователями
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Получить пользователя по его имени
    /// </summary>
    /// <param name="name">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Результат операции с пользователем</returns>
    public Task<OperationResult<User>> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    /// <param name="createUserDto">Объект передачи данных для создания пользователя</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Результат операции с пользователем</returns>
    public Task<OperationResult<User>> CreateAsync(InternalCreateUserDto createUserDto, CancellationToken cancellationToken = default);
}