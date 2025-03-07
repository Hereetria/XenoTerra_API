using HotChocolate;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Schemas.Resolvers;

namespace XenoTerra.WebAPI.Schemas.Queries.BlockUser
{
    public class BlockUserQuery
    {
        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetBlockUsersAsync(
            List<Guid>? ids,
            [Service] BlockUserResolver blockUserResolver,
            [Service] IBlockUserServiceBLL service,
            IResolverContext context)
            => await blockUserResolver.GetBlockUsersAsync(ids, service, context);

            var result = await service.GetByIdsWithRelationsAsync(
                ids ?? await service.GetAllIdsAsync(),
                selectedFields





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
