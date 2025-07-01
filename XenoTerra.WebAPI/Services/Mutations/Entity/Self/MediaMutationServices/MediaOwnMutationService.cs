using AutoMapper;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.MediaMutationServices
{
    public class MediaOwnMutationService(IMapper mapper)
        : MutationService<Media, ResultMediaOwnDto, CreateMediaOwnDto, UpdateMediaOwnDto, Guid>(mapper),
        IMediaOwnMutationService
    {
    }
}
