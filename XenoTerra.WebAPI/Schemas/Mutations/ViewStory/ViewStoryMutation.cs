using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.ViewStoryServices;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.ViewStory
{
    public class ViewStoryMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new ViewStory")]
        public async Task<ResultViewStoryDto> CreateViewStoryAsync(CreateViewStoryDto createViewStoryDto, [Service] IViewStoryServiceBLL viewStoryServiceBLL)
        {
            var result = await viewStoryServiceBLL.CreateAsync(createViewStoryDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing ViewStory")]
        public async Task<ResultViewStoryDto> UpdateViewStoryAsync(UpdateViewStoryDto updateViewStoryDto, [Service] IViewStoryServiceBLL viewStoryServiceBLL)
        {
            var result = await viewStoryServiceBLL.UpdateAsync(updateViewStoryDto);
            return result;
        }

        [GraphQLDescription("Delete a ViewStory by ID")]
        public async Task<bool> DeleteViewStoryAsync(Guid id, [Service] IViewStoryServiceBLL viewStoryServiceBLL)
        {
            var result = await viewStoryServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
