using XenoTerra.BussinessLogicLayer.Services.Entity.PostService;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostMutations
{
    public class PostMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Post")]
        public async Task<ResultPostDto> CreatePostAsync(CreatePostDto createPostDto, [Service] IPostWriteService postWriteService)
        {
            var result = await postWriteService.CreateAsync(createPostDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Post")]
        public async Task<ResultPostDto> UpdatePostAsync(UpdatePostDto updatePostDto, [Service] IPostWriteService postWriteService)
        {
            var result = await postWriteService.UpdateAsync(updatePostDto);
            return result;
        }

        [GraphQLDescription("Delete a Post by ID")]
        public async Task<bool> DeletePostAsync(Guid id, [Service] IPostWriteService postWriteService)
        {
            var result = await postWriteService.DeleteAsync(id);
            return result;
        }
    }
}
