using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.ViewStory
{
    public class ViewStoryMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new ViewStory")]
        public async Task<ResultViewStoryDto> CreateViewStoryAsync(CreateViewStoryDto createViewStoryDto, [Service] IViewStoryWriteService viewStoryWriteService)
        {
            var result = await viewStoryWriteService.CreateAsync(createViewStoryDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing ViewStory")]
        public async Task<ResultViewStoryDto> UpdateViewStoryAsync(UpdateViewStoryDto updateViewStoryDto, [Service] IViewStoryWriteService viewStoryWriteService)
        {
            var result = await viewStoryWriteService.UpdateAsync(updateViewStoryDto);
            return result;
        }

        [GraphQLDescription("Delete a ViewStory by ID")]
        public async Task<bool> DeleteViewStoryAsync(Guid id, [Service] IViewStoryWriteService viewStoryWriteService)
        {
            var result = await viewStoryWriteService.DeleteAsync(id);
            return result;
        }
    }
}
