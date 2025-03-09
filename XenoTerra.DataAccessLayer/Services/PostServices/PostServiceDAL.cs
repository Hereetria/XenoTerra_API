

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.DataAccessLayer.Services.PostServices
{
    
    public class PostServiceDAL : GenericRepositoryDAL<Post, ResultPostDto, ResultPostWithRelationsDto, CreatePostDto, UpdatePostDto, Guid>, IPostServiceDAL

    {

        public PostServiceDAL(AppDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public IQueryable<ResultPostDto> TGetMainstreamPosts(Guid userId, int seed)
        {
            var query = _context.Posts
                .Where(post => post.Likes == null || !post.Likes.Any(like => like.UserId == userId));

            var orderedPostIds = _context.Posts
                .FromSqlRaw("SELECT PostId FROM Posts ORDER BY CAST(HASHBYTES('MD5', CONCAT(PostId, {0})) AS UNIQUEIDENTIFIER) OFFSET 0 ROWS", seed)
                .Select(p => p.PostId);

            var ordered = query
                .Join(orderedPostIds, post => post.PostId, orderedId => orderedId, (post, orderedId) => post);

            var result = ordered
                .ProjectTo<ResultPostDto>(_mapper.ConfigurationProvider);

            return result;
        }

        public IQueryable<ResultPostDto> TGetFollowingPosts(Guid userId)
        {
            var query = _context.Posts
                .Where(post =>
                    _context.Follows
                        .Where(f => f.FollowerId == userId)
                        .Select(f => f.FollowingId)
                        .Contains(post.UserId)
                    &&
                    (post.Likes == null || !post.Likes.Any(like => like.UserId == userId))

                )
                .OrderBy(post => post.CreatedAt);

            var result = query.ProjectTo<ResultPostDto>(_mapper.ConfigurationProvider);

            return result;


        }

    }
}