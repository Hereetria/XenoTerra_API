using HotChocolate.Resolvers;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.BlockUsera
{
    public class Test
    {
        public IQueryable<ResultBlockUserWithRelationsDto> ModifyQuery(
            IQueryable<BlockUser> query,
            IResolverContext context)
        {
            var dbContext = context.Service<AppDbContext>();
            var selectedNestedFields = GraphQLFieldProvider.GetNestedSelectedFields(context, "blockingUser");
            var selector = SimpleProjectonExpressionProvider.CreateSelectorExpression<User>(selectedNestedFields);

            var innerQuery = dbContext.Set<User>().Select(selector);

            var joinedQuery = query.Join<BlockUser, User, Guid, ResultBlockUserWithRelationsDto>(
                innerQuery,
                blockUser => blockUser.BlockingUserId,
                user => user.Id,
                (blockUser, blockingUser) => new ResultBlockUserWithRelationsDto
                {
                    BlockUserId = blockUser.BlockUserId,
                    BlockingUserId = blockUser.BlockingUserId,
                    BlockedUserId = blockUser.BlockedUserId,
                    BlockedAt = blockUser.BlockedAt,

                    BlockedUser = blockUser.BlockedUser != null ? MapUserToDto(blockUser.BlockedUser) : null,
                    BlockingUser = blockingUser != null ? MapUserToDto(blockingUser) : null
                });

            return joinedQuery;
        }

        private static ResultUserDto MapUserToDto(XenoTerra.EntityLayer.Entities.User user)
        {
            if (user == null) return null;

            return new ResultUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }

    }
}
