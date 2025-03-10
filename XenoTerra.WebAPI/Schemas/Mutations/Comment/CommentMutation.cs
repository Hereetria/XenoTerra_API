using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentService;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Comment
{
    public class CommentMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Comment")]
        public async Task<ResultCommentDto> CreateCommentAsync(CreateCommentDto createCommentDto, [Service] ICommentWriteService blockUserWriteService)
        {
            var result = await blockUserWriteService.CreateAsync(createCommentDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Comment")]
        public async Task<ResultCommentDto> UpdateCommentAsync(UpdateCommentDto updateCommentDto, [Service] ICommentWriteService blockUserWriteService)
        {
            var result = await blockUserWriteService.UpdateAsync(updateCommentDto);
            return result;
        }

        [GraphQLDescription("Delete a Comment by ID")]
        public async Task<bool> DeleteCommentAsync(Guid id, [Service] IBlockUserWriteService blockUserWriteService)
        {
            var result = await blockUserWriteService.DeleteAsync(id);
            return result;
        }
    }
}
