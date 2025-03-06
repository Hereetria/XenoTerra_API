using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.MediaServices;
using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Media
{
    public class MediaMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Media")]
        public async Task<ResultMediaDto> CreateMediaAsync(CreateMediaDto createMediaDto, [Service] IMediaServiceBLL mediaServiceBLL)
        {
            var result = await mediaServiceBLL.CreateAsync(createMediaDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Media")]
        public async Task<ResultMediaDto> UpdateMediaAsync(UpdateMediaDto updateMediaDto, [Service] IMediaServiceBLL mediaServiceBLL)
        {
            var result = await mediaServiceBLL.UpdateAsync(updateMediaDto);
            return result;
        }

        [GraphQLDescription("Delete a Media by ID")]
        public async Task<bool> DeleteMediaAsync(Guid id, [Service] IMediaServiceBLL mediaServiceBLL)
        {
            var result = await mediaServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
