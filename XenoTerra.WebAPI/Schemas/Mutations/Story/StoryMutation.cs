using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.StoryServices;
using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Story
{
    public class StoryMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Story")]
        public async Task<ResultStoryDto> CreateStoryAsync(CreateStoryDto createStoryDto, [Service] IStoryServiceBLL storyServiceBLL)
        {
            var result = await storyServiceBLL.CreateAsync(createStoryDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Story")]
        public async Task<ResultStoryDto> UpdateStoryAsync(UpdateStoryDto updateStoryDto, [Service] IStoryServiceBLL storyServiceBLL)
        {
            var result = await storyServiceBLL.UpdateAsync(updateStoryDto);
            return result;
        }

        [GraphQLDescription("Delete a Story by ID")]
        public async Task<bool> DeleteStoryAsync(Guid id, [Service] IStoryServiceBLL storyServiceBLL)
        {
            var result = await storyServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
