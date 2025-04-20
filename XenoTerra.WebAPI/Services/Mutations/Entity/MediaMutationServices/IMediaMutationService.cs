using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.MediaMutationServices
{
    public interface IMediaMutationService : IMutationService<Media, ResultMediaDto, CreateMediaDto, UpdateMediaDto, Guid>
    {
    }
}
