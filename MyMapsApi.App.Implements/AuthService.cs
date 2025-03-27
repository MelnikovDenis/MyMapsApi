using AutoMapper;
using MyMapsApi.App.Contracts;
using MyMapsApi.App.Contracts.Dtos;
using MyMapsApi.App.Implements.TokenService;
using MyMapsApi.App.Infra.Contracts;
using MyMapsApi.App.Infra.Contracts.Dtos;
using MyMapsApi.Core.Models;
using MyMapsApi.Shared;

namespace MyMapsApi.App.Implements;

internal class AuthService(IUserRepository repo, JwtTokenService tokenService, IMapper mapper) : IAuthService
{
    private readonly IUserRepository _repo = repo;

    private readonly IMapper _mapper = mapper;

    private readonly JwtTokenService _tokenService = tokenService;

    public async Task<OperationResult<string>> LoginOrRegisterAsync(LoginOrRegisterDto loginOrRegisterDto, CancellationToken cancellationToken = default)
    {
        var getUserResult = await _repo.GetByNameAsync(loginOrRegisterDto.Name, cancellationToken);

        if (getUserResult.IsSuccess)
        {
            if (!HashHelper.VerifyHash(getUserResult.Data!.PasswordHash, loginOrRegisterDto.Password))
            {
                return new OperationResult<string>("Неверное имя пользователя или пароль", 401);
            }

            return new OperationResult<string>(_tokenService.CreateToken(loginOrRegisterDto.Name));
        }

        var createUserDto = _mapper.Map<InternalCreateUserDto>(loginOrRegisterDto);

        var createUserResult = await _repo.CreateAsync(createUserDto, cancellationToken);

        if (createUserResult.IsSuccess) 
        {
            return new OperationResult<string>(_tokenService.CreateToken(createUserResult.Data!.Name));
        }

        return createUserResult.Convert<string>((user) => _tokenService.CreateToken(user.Name));
    }
}
