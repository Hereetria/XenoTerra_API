using HotChocolate;
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

            //var oldQuery = resolver.ModifyQuery(query, context);
            var joinedQuery = resolver.ApplyJoinWithProjection<
                BlockUser,
                User,
                ResultBlockUserWithRelationsDto,
                ResultUserDto,
                Guid>(
                    query,
                    context,
                    "blockingUser");

            return await joinedQuery.ToListAsync();
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
