using AutoMapper;
using MyMapsApi.App.Contracts;
using MyMapsApi.App.Contracts.Dtos;
using MyMapsApi.App.Infra.Contracts;
using MyMapsApi.App.Infra.Contracts.Dtos;
using MyMapsApi.Core.Models;

namespace MyMapsApi.App.Implements;

public class PostService(IPostRepository repo, IMapper mapper) : IPostService
{
    private readonly IPostRepository _repo = repo;

    private readonly IMapper _mapper = mapper;

    public async Task<OperationResult<PostInfoDto>> CreateAsync(CreatePostDto createPostDto, string name, CancellationToken cancellationToken = default)
    {
        var internalDto = new InternalCreatePostDto() 
        { 
            Commentary = createPostDto.Commentary, 
            Latitude = createPostDto.Latitude, 
            Longitude = createPostDto.Longitude, 
            Name = name 
        };

        var createResult = await _repo.CreateAsync(internalDto, cancellationToken);

        return createResult.Convert(_mapper.Map<PostInfoDto>);
    }

    public Task DeleteAsync(Guid postId, CancellationToken cancellationToken = default)
    {
        return _repo.DeleteAsync(postId, cancellationToken);
    }

    public async Task<OperationResult<IEnumerable<PostInfoDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var getAllResult = await _repo.GetAllAsync(cancellationToken);

        return getAllResult.Convert(x => x.Select(_mapper.Map<PostInfoDto>));
    }
}
