using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.FollowServices;
using XenoTerra.DTOLayer.Dtos.FollowDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Follow
{
    public class FollowMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Follow")]
        public async Task<ResultFollowByIdDto> CreateFollowAsync(CreateFollowDto createFollowDto, [Service] IFollowServiceBLL followServiceBLL)
        {
            var result = await followServiceBLL.CreateAsync(createFollowDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Follow")]
        public async Task<ResultFollowByIdDto> UpdateFollowAsync(UpdateFollowDto updateFollowDto, [Service] IFollowServiceBLL followServiceBLL)
        {
            var result = await followServiceBLL.UpdateAsync(updateFollowDto);
            return result;
        }

        [GraphQLDescription("Delete a Follow by ID")]
        public async Task<bool> DeleteFollowAsync(Guid id, [Service] IFollowServiceBLL followServiceBLL)
        {
            var result = await followServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
