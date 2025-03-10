using XenoTerra.BussinessLogicLayer.Services.Entity.PostTagService;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.PostTag
{
    public class PostTagMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new PostTag")]
        public async Task<ResultPostTagDto> CreatePostTagAsync(CreatePostTagDto createPostTagDto, [Service] IPostTagWriteService postTagWriteService)
        {
            var result = await postTagWriteService.CreateAsync(createPostTagDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing PostTag")]
        public async Task<ResultPostTagDto> UpdatePostTagAsync(UpdatePostTagDto updatePostTagDto, [Service] IPostTagWriteService postTagWriteService)
        {
            var result = await postTagWriteService.UpdateAsync(updatePostTagDto);
            return result;
        }

        [GraphQLDescription("Delete a PostTag by ID")]
        public async Task<bool> DeletePostTagAsync(Guid id, [Service] IPostTagWriteService postTagWriteService)
        {
            var result = await postTagWriteService.DeleteAsync(id);
            return result;
        }
    }
}
