using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowService;
using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.FollowMutations
{
    public class FollowMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Follow")]
        public async Task<ResultFollowDto> CreateFollowAsync(CreateFollowDto createFollowDto, [Service] IFollowWriteService followWriteService)
        {
            var result = await followWriteService.CreateAsync(createFollowDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Follow")]
        public async Task<ResultFollowDto> UpdateFollowAsync(UpdateFollowDto updateFollowDto, [Service] IFollowWriteService followWriteService)
        {
            var result = await followWriteService.UpdateAsync(updateFollowDto);
            return result;
        }

        [GraphQLDescription("Delete a Follow by ID")]
        public async Task<bool> DeleteFollowAsync(Guid id, [Service] IFollowWriteService followWriteService)
        {
            var result = await followWriteService.DeleteAsync(id);
            return result;
        }
    }
}
