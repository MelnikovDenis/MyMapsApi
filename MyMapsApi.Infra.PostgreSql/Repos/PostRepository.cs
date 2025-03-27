using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMapsApi.App.Infra.Contracts;
using MyMapsApi.App.Infra.Contracts.Dtos;
using MyMapsApi.Core.Entities;
using MyMapsApi.Core.Models;

namespace MyMapsApi.Infra.PostgreSql.Repos;

internal class PostRepository(AppDbContext context, IMapper mapper) : IPostRepository
{
    private readonly AppDbContext _context = context;

    private readonly IMapper _mapper = mapper;

    public async Task<OperationResult<Post>> CreateAsync(InternalCreatePostDto createPostDto, CancellationToken cancellationToken = default)
    {
        var post = _mapper.Map<Post>(createPostDto);

        _context.Posts.Add(post);

        await _context.SaveChangesAsync(cancellationToken);

        return new OperationResult<Post>(post);
    }

    public Task DeleteAsync(Guid postId, CancellationToken cancellationToken = default)
    {
        return _context.Posts.Where(x => x.Id == postId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<OperationResult<IEnumerable<Post>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var posts = await _context.Posts.Include(x => x.User).ToListAsync(cancellationToken);

        return new OperationResult<IEnumerable<Post>>(posts);
    }
}
