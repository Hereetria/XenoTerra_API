using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.BlockUserMutations
{
    public class BlockUserMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new BlockUser")]
        public async Task<ResultBlockUserDto> CreateBlockUserAsync(CreateBlockUserDto createBlockUserDto, [Service] IBlockUserWriteService blockUserWriteService)
        {
            var result = await blockUserWriteService.CreateAsync(createBlockUserDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing BlockUser")]
        public async Task<ResultBlockUserDto> UpdateBlockUser(UpdateBlockUserDto updateBlockUserDto, [Service] IBlockUserWriteService blockUserWriteService)
        {
            var result = await blockUserWriteService.UpdateAsync(updateBlockUserDto);
            return result;
        }

        [GraphQLDescription("Delete a BlockUser by ID")]
        public async Task<bool> DeleteBlockUserAsync(Guid id, [Service] IBlockUserWriteService blockUserWriteService)
        {
            var result = await blockUserWriteService.DeleteAsync(id);
            return result;
        }
    }

}
