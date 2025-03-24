using XenoTerra.BussinessLogicLayer.Services.Entity.LikeService;
using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.LikeMutations
{
    public class LikeMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Like")]
        public async Task<ResultLikeDto> CreateLikeAsync(CreateLikeDto createLikeDto, [Service] ILikeWriteService  likeWriteService)
        {
            var result = await likeWriteService.CreateAsync(createLikeDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Like")]
        public async Task<ResultLikeDto> UpdateLikeAsync(UpdateLikeDto updateLikeDto, [Service] ILikeWriteService  likeWriteService)
        {
            var result = await likeWriteService.UpdateAsync(updateLikeDto);
            return result;
        }

        [GraphQLDescription("Delete a Like by ID")]
        public async Task<bool> DeleteLikeAsync(Guid id, [Service] ILikeWriteService  likeWriteService)
        {
            var result = await likeWriteService.DeleteAsync(id);
            return result;
        }
    }
}
