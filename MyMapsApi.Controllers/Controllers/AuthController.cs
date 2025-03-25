using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMapsApi.App.Contracts;
using MyMapsApi.App.Contracts.Dtos;
using MyMapsApi.Core.Models;

namespace MyMapsApi.Controllers.Controllers;

/// <summary>
/// Контроллер авторизации и аутентификации
/// </summary>
/// <param name="authService">Сервис аутентификации и авторизации</param>
[Route("api/auth")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{

    private readonly IAuthService _authService = authService;

    /// <summary>
    /// Получить jwt токен
    /// </summary>
    /// <param name="loginOrRegisterDto">Dto для логина или регистрации</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>OperationResult с токеном</returns>
    [HttpPost("login-or-register")]
    [AllowAnonymous]
    public async Task<ActionResult<OperationResult<string>>> LoginAsync(LoginOrRegisterDto loginOrRegisterDto,
        CancellationToken cancellationToken = default)
    {
        var result = await _authService.LoginOrRegisterAsync(loginOrRegisterDto, cancellationToken);

        return StatusCode(result.StatusCode, result);
    }
}