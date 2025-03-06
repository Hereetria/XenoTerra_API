using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.PostServices;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Post
{
    public class PostMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Post")]
        public async Task<ResultPostDto> CreatePostAsync(CreatePostDto createPostDto, [Service] IPostServiceBLL postServiceBLL)
        {
            var result = await postServiceBLL.CreateAsync(createPostDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Post")]
        public async Task<ResultPostDto> UpdatePostAsync(UpdatePostDto updatePostDto, [Service] IPostServiceBLL postServiceBLL)
        {
            var result = await postServiceBLL.UpdateAsync(updatePostDto);
            return result;
        }

        [GraphQLDescription("Delete a Post by ID")]
        public async Task<bool> DeletePostAsync(Guid id, [Service] IPostServiceBLL postServiceBLL)
        {
            var result = await postServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
