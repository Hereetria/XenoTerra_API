using XenoTerra.BussinessLogicLayer.Services.Entity.MediaService;
using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Media
{
    public class MediaMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Media")]
        public async Task<ResultMediaDto> CreateMediaAsync(CreateMediaDto createMediaDto, [Service] IMediaWriteService mediaWriteService)
        {
            var result = await mediaWriteService.CreateAsync(createMediaDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Media")]
        public async Task<ResultMediaDto> UpdateMediaAsync(UpdateMediaDto updateMediaDto, [Service] IMediaWriteService mediaWriteService)
        {
            var result = await mediaWriteService.UpdateAsync(updateMediaDto);
            return result;
        }

        [GraphQLDescription("Delete a Media by ID")]
        public async Task<bool> DeleteMediaAsync(Guid id, [Service] IMediaWriteService mediaWriteService)
        {
            var result = await mediaWriteService.DeleteAsync(id);
            return result;
        }
    }
}
