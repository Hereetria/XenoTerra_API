using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.PostTagServices;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.PostTag
{
    public class PostTagMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new PostTag")]
        public async Task<ResultPostTagDto> CreatePostTagAsync(CreatePostTagDto createPostTagDto, [Service] IPostTagServiceBLL postTagServiceBLL)
        {
            var result = await postTagServiceBLL.CreateAsync(createPostTagDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing PostTag")]
        public async Task<ResultPostTagDto> UpdatePostTagAsync(UpdatePostTagDto updatePostTagDto, [Service] IPostTagServiceBLL postTagServiceBLL)
        {
            var result = await postTagServiceBLL.UpdateAsync(updatePostTagDto);
            return result;
        }

        [GraphQLDescription("Delete a PostTag by ID")]
        public async Task<bool> DeletePostTagAsync(Guid id, [Service] IPostTagServiceBLL postTagServiceBLL)
        {
            var result = await postTagServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
