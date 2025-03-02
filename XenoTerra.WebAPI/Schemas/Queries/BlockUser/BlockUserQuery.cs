using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.BlockUser
{
    public class BlockUserQuery
    {
        [UseProjection]
        [GraphQLDescription("Get all BlockUsers")]
        public IQueryable<ResultBlockUserDto> GetAllBlockUsers([Service] IBlockUserServiceBLL blockUserServiceBLL)
        {
            var result = blockUserServiceBLL.GetAllQuerable();
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Get BlockUser by ID")]
        public IQueryable<ResultBlockUserByIdDto> GetBlockUserById(Guid id, [Service] IBlockUserServiceBLL blockUserServiceBLL)
        {
            var result = blockUserServiceBLL.GetByIdQuerable(id);
            if (result == null)
            {
                throw new Exception($"BlockUser with ID {id} not found");
            }
            return result;
        }
    }
}
