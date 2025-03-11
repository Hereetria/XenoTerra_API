using XenoTerra.BussinessLogicLayer.Services.Entity.StoryService;
using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.StoryMutations
{
    public class StoryMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Story")]
        public async Task<ResultStoryDto> CreateStoryAsync(CreateStoryDto createStoryDto, [Service] IStoryWriteService storyWriteService)
        {
            var result = await storyWriteService.CreateAsync(createStoryDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Story")]
        public async Task<ResultStoryDto> UpdateStoryAsync(UpdateStoryDto updateStoryDto, [Service] IStoryWriteService storyWriteService)
        {
            var result = await storyWriteService.UpdateAsync(updateStoryDto);
            return result;
        }

        [GraphQLDescription("Delete a Story by ID")]
        public async Task<bool> DeleteStoryAsync(Guid id, [Service] IStoryWriteService storyWriteService)
        {
            var result = await storyWriteService.DeleteAsync(id);
            return result;
        }
    }
}
