using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.BlockUser
{
    public class BlockUserMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new BlockUser")]
        public async Task<ResultBlockUserDto> CreateBlockUserAsync(CreateBlockUserDto createBlockUserDto, [Service] IBlockUserServiceBLL blockUserServiceBLL)
        {
            var result = await blockUserServiceBLL.CreateAsync(createBlockUserDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing BlockUser")]
        public async Task<ResultBlockUserDto> UpdateBlockUser(UpdateBlockUserDto updateBlockUserDto, [Service] IBlockUserServiceBLL blockUserServiceBLL)
        {
            var result = await blockUserServiceBLL.UpdateAsync(updateBlockUserDto);
            return result;
        }

        [GraphQLDescription("Delete a BlockUser by ID")]
        public async Task<bool> DeleteBlockUserAsync(Guid id, [Service] IBlockUserServiceBLL blockUserServiceBLL)
        {
            var result = await blockUserServiceBLL.DeleteAsync(id);
            return result;
        }
    }

}
