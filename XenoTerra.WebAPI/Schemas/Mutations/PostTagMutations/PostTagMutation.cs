using XenoTerra.BussinessLogicLayer.Services.Entity.PostTagService;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.PostTagMutations
{
    public class PostTagMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new PostTag")]
        public async Task<ResultUserPostTagDto> CreatePostTagAsync(CreateUserPostTagDto createPostTagDto, [Service] IUserPostTagWriteService postTagWriteService)
        {
            var result = await postTagWriteService.CreateAsync(createPostTagDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing PostTag")]
        public async Task<ResultUserPostTagDto> UpdatePostTagAsync(UpdateUserPostTagDto updatePostTagDto, [Service] IUserPostTagWriteService postTagWriteService)
        {
            var result = await postTagWriteService.UpdateAsync(updatePostTagDto);
            return result;
        }

        [GraphQLDescription("Delete a PostTag by ID")]
        public async Task<bool> DeletePostTagAsync(Guid id, [Service] IUserPostTagWriteService postTagWriteService)
        {
            var result = await postTagWriteService.DeleteAsync(id);
            return result;
        }
    }
}
