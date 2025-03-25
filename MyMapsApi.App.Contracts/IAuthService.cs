using MyMapsApi.App.Contracts.Dtos;
using MyMapsApi.Core.Models;

namespace MyMapsApi.App.Contracts;

/// <summary>
/// Интерфейс сервиса для авторизации
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Залогиниться или зарегистрироваться
    /// </summary>
    /// <param name="loginOrRegisterDto">Объект передачи данных для логина или регистрации</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Результат операции с токеном авторизации</returns>
    public Task<OperationResult<string>> LoginOrRegisterAsync(LoginOrRegisterDto loginOrRegisterDto, CancellationToken cancellationToken = default);
}
