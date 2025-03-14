using HotChocolate;
using HotChocolate.Data.Projections.Context;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.BlockUserQueries
{
    public class BlockUserQuery
    {
        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetAllBlockUsersAsync(
            [Service] IBlockUserReadService blockUserReadService,
            [Service] BlockUserResolver resolver,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = blockUserReadService.FetchAllQueryable(selectedFields);

            if (query is null)
                throw new Exception($"{nameof(query)} cannot be null");

            query = resolver.ModifyQuery(query, context);

            var blockUsers = await query.ToListAsync();

            var result = blockUsers.Select(b => new ResultBlockUserWithRelationsDto
            {
                BlockUserId = b.BlockUserId,
                BlockingUserId = b.BlockingUserId,
                BlockedUserId = b.BlockedUserId,
                BlockedAt = b.BlockedAt,
                BlockingUser = b.BlockingUser != null ? new ResultUserDto
                {
                    Id = b.BlockingUser.Id,
                    UserName = b.BlockingUser.UserName,
                    Email = b.BlockingUser.Email
                } : null,
                BlockedUser = b.BlockedUser != null ? new ResultUserDto
                {
                    Id = b.BlockedUser.Id,
                    UserName = b.BlockedUser.UserName,
                    Email = b.BlockedUser.Email
                } : null
            });

            return result;
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



        //[UseProjection]
        //[GraphQLDescription("Get BlockUser by ID")]
        //public IQueryable<ResultBlockUserByIdDto> GetBlockUserById(Guid id, [Service] IBlockUserServiceBLL blockUserServiceBLL)
        //{
        //    var result = blockUserServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"BlockUser with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
