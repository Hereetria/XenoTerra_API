using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostService;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostMutations
{
    public class SavedPostMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new SavedPost")]
        public async Task<ResultSavedPostDto> CreateSavedPostAsync(CreateSavedPostDto createSavedPostDto, [Service] ISavedPostWriteService savedPostWriteService)
        {
            var result = await savedPostWriteService.CreateAsync(createSavedPostDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing SavedPost")]
        public async Task<ResultSavedPostDto> UpdateSavedPostAsync(UpdateSavedPostDto updateSavedPostDto, [Service] ISavedPostWriteService savedPostWriteService)
        {
            var result = await savedPostWriteService.UpdateAsync(updateSavedPostDto);
            return result;
        }

        [GraphQLDescription("Delete a SavedPost by ID")]
        public async Task<bool> DeleteSavedPostAsync(Guid id, [Service] ISavedPostWriteService savedPostWriteService)
        {
            var result = await savedPostWriteService.DeleteAsync(id);
            return result;
        }
    }
}
