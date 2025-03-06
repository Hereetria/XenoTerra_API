using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.Schemas.DataLoaders;

namespace XenoTerra.WebAPI.Schemas.Queries.BlockUser
{
    public class BlockUserQuery
    {
        [UseProjection]
        public IQueryable<ResultBlockUserWithRelationsDto> GetBlockUsers(
            List<Guid>? ids,
            [Service] IBlockUserServiceBLL service
        ) => service.GetByIdsQuerableWithRelations(ids ?? service.GetAllIdsAsync().Result);




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
