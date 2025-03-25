using Microsoft.AspNetCore.Mvc;
using MyMapsApi.App.Contracts.Dtos;
using MyMapsApi.App.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace MyMapsApi.Controllers.Controllers;

/// <summary>
/// Контроллер для работы с постами
/// </summary>
/// <param name="logger">Логгер</param>
/// <param name="postService">Сервис для работы с постами</param>
[Route("api/posts")]
[Authorize]
[ApiController]
public class PostsController(IPostService postService, ILogger<PostsController> logger) : ControllerBase
{

    private readonly IPostService _postService = postService;

    private readonly ILogger<PostsController> _logger = logger;

    /// <summary>
    /// Создать пост
    /// </summary>
    /// <param name="createPostDto">Объект передачи данных для содания поста</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Результат операции с созданным постом</returns>
    /// <exception cref="ArgumentNullException">Ошибка возникающая, если отсутствует claim с полем name</exception>
    [HttpPost("")]
    public async Task<ActionResult<PostInfoDto>> CreateAsync(CreatePostDto createPostDto, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Обработка запроса {Request.Method}: {Request.Path.ToString()}");

        var authorName = User.FindFirst("name")?.Value
            ?? throw new ArgumentNullException("name", "Где твой name claim?");

        var createResult = await _postService.CreateAsync(createPostDto, authorName, cancellationToken);

        return StatusCode(createResult.StatusCode, createResult);
    }

    /// <summary>
    /// Удалить пост
    /// </summary>
    /// <param name="postId">Id поста</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Ok</returns>
    [HttpDelete("")]
    public async Task<IActionResult> DeleteAsync([FromQuery, Required] Guid postId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Обработка запроса {Request.Method}: {Request.Path.ToString()}");

        await _postService.DeleteAsync(postId, cancellationToken);

        return Ok();
    }

    /// <summary>
    /// Получить список всех постов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    /// <returns>Результат операции со списком всех постов</returns>
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<PostInfoDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Обработка запроса {Request.Method}: {Request.Path.ToString()}");

        var getAllResult = await _postService.GetAllAsync(cancellationToken);

        return StatusCode(getAllResult.StatusCode, getAllResult);
    }
}