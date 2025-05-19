using Microsoft.EntityFrameworkCore;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Concrete
{
    public class PublicUserIdProvider(AppDbContext dbContext) : IPublicUserIdProvider
    {
        public async Task<List<Guid>> GetPublicUserIdsAsync()
        {
            return await dbContext.Users
                .Where(u => !u.UserSetting.IsPrivate)
                .Select(u => u.Id)
                .ToListAsync();
        }
    }
}
