using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.LikeServices;
using XenoTerra.DTOLayer.Dtos.LikeDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Like
{
    public class LikeMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Like")]
        public async Task<ResultLikeDto> CreateLikeAsync(CreateLikeDto createLikeDto, [Service] ILikeServiceBLL likeServiceBLL)
        {
            var result = await likeServiceBLL.CreateAsync(createLikeDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Like")]
        public async Task<ResultLikeDto> UpdateLikeAsync(UpdateLikeDto updateLikeDto, [Service] ILikeServiceBLL likeServiceBLL)
        {
            var result = await likeServiceBLL.UpdateAsync(updateLikeDto);
            return result;
        }

        [GraphQLDescription("Delete a Like by ID")]
        public async Task<bool> DeleteLikeAsync(Guid id, [Service] ILikeServiceBLL likeServiceBLL)
        {
            var result = await likeServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
