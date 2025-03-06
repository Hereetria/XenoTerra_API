using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.HighlightServices;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Highlight
{
    public class HighlightMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Highlight")]
        public async Task<ResultHighlightDto> CreateHighlightAsync(CreateHighlightDto createHighlightDto, [Service] IHighlightServiceBLL highlightServiceBLL)
        {
            var result = await highlightServiceBLL.CreateAsync(createHighlightDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Highlight")]
        public async Task<ResultHighlightDto> UpdateHighlightAsync(UpdateHighlightDto updateHighlightDto, [Service] IHighlightServiceBLL highlightServiceBLL)
        {
            var result = await highlightServiceBLL.UpdateAsync(updateHighlightDto);
            return result;
        }

        [GraphQLDescription("Delete a Highlight by ID")]
        public async Task<bool> DeleteHighlightAsync(Guid id, [Service] IHighlightServiceBLL highlightServiceBLL)
        {
            var result = await highlightServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
