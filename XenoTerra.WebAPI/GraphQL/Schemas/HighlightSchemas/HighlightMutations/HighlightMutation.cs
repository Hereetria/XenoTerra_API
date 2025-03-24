using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.HighlightService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightMutations
{
    public class HighlightMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Highlight")]
        public async Task<ResultHighlightDto> CreateHighlightAsync(CreateHighlightDto createHighlightDto, [Service] IHighlightWriteService highlightWriteService)
        {
            var result = await highlightWriteService.CreateAsync(createHighlightDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Highlight")]
        public async Task<ResultHighlightDto> UpdateHighlightAsync(UpdateHighlightDto updateHighlightDto, [Service] IHighlightWriteService highlightWriteService)
        {
            var result = await highlightWriteService.UpdateAsync(updateHighlightDto);
            return result;
        }

        [GraphQLDescription("Delete a Highlight by ID")]
        public async Task<bool> DeleteHighlightAsync(Guid id, [Service] IHighlightWriteService highlightWriteService)
        {
            var result = await highlightWriteService.DeleteAsync(id);
            return result;
        }
    }
}
