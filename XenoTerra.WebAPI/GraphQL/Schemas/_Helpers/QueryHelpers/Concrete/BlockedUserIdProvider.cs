using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete
{
    public class BlockedUserIdProvider(AppDbContext dbContext) : IBlockedUserIdProvider
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<List<Guid>> GetBlockedUserIdsAsync(Guid currentUserId)
        {
            return await _dbContext.Set<BlockUser>()
                .Where(b => b.BlockingUserId == currentUserId)
                .Select(b => b.BlockedUserId)
                .ToListAsync();
        }
    }
}
