using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.CommentServices;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Comment
{
    public class CommentMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Comment")]
        public async Task<ResultCommentDto> CreateCommentAsync(CreateCommentDto createCommentDto, [Service] ICommentServiceBLL commentServiceBLL)
        {
            var result = await commentServiceBLL.CreateAsync(createCommentDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Comment")]
        public async Task<ResultCommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto, [Service] ICommentServiceBLL commentServiceBLL)
        {
            var result = await commentServiceBLL.UpdateAsync(updateCommentDto);
            return result;
        }

        [GraphQLDescription("Delete a Comment by ID")]
        public async Task<bool> DeleteCommentAsync(Guid id, [Service] ICommentServiceBLL commentServiceBLL)
        {
            var result = await commentServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
