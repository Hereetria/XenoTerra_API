using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete
{
    public class FollowedUserIdProvider(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor) : IFollowedUserIdProvider
    {
        private readonly AppDbContext _dbContext = dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task<List<Guid>> GetFollowedUserIdsAsync()
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(_httpContextAccessor.HttpContext);

            return await _dbContext.Set<Follow>()
                .Where(f => f.FollowerId == currentUserId)
                .Select(f => f.FollowingId)
                .ToListAsync();
        }
    }
}
