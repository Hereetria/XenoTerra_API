using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.MediaMutationServices
{
    public interface IMediaSelfMutationService : IMutationService<Media, ResultMediaDto, CreateMediaDto, UpdateMediaDto, Guid>
    {
    }
}
