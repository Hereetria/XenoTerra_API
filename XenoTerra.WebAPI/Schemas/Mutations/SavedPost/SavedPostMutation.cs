using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.SavedPostServices;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.SavedPost
{
    public class SavedPostMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new SavedPost")]
        public async Task<ResultSavedPostByIdDto> CreateSavedPostAsync(CreateSavedPostDto createSavedPostDto, [Service] ISavedPostServiceBLL savedPostServiceBLL)
        {
            var result = await savedPostServiceBLL.CreateAsync(createSavedPostDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing SavedPost")]
        public async Task<ResultSavedPostByIdDto> UpdateSavedPostAsync(UpdateSavedPostDto updateSavedPostDto, [Service] ISavedPostServiceBLL savedPostServiceBLL)
        {
            var result = await savedPostServiceBLL.UpdateAsync(updateSavedPostDto);
            return result;
        }

        [GraphQLDescription("Delete a SavedPost by ID")]
        public async Task<bool> DeleteSavedPostAsync(Guid id, [Service] ISavedPostServiceBLL savedPostServiceBLL)
        {
            var result = await savedPostServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
