using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.BlockUser
{
    public class BlockUserQuery
    {
        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetBlockUsersAsync(
            List<Guid>? ids,
            [Service] IBlockUserServiceBLL service,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var result = await service.GetByIdsWithRelationsAsync(
                ids, selectedFields
            );

            return result;
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
