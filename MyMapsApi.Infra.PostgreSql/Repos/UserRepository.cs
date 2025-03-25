using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyMapsApi.Core.Entities;
using MyMapsApi.Core.Models;
using MyMapsApi.Infra.Contracts;
using MyMapsApi.Infra.Contracts.Dtos;

namespace MyMapsApi.Infra.PostgreSql.Repos;

internal class UserRepository(AppDbContext context, IMapper mapper, ILogger<UserRepository> logger) : IUserRepository
{
    private readonly AppDbContext _context = context;

    private readonly IMapper _mapper = mapper;

    private readonly ILogger<UserRepository> _logger = logger;

    public async Task<OperationResult<User>> CreateAsync(InternalCreateUserDto createUserDto, CancellationToken cancellationToken = default)
    {
        var user = _mapper.Map<User>(createUserDto);

        _context.Users.Add(user);

        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
            return new OperationResult<User>($"Не удалось сохранить такого пользователя в БД", 400);
        }

        return new OperationResult<User>(user);
    }

    public async Task<OperationResult<User>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.Include(x => x.Posts).FirstOrDefaultAsync(x => x.Name == name, cancellationToken);

        if (user == null)
        {
            return new OperationResult<User>($"Не найден пользователь с именем: {name}", 404);
        }

        return new OperationResult<User>(user);
    }
}