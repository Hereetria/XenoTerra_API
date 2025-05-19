using AutoMapper;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.MediaMutationServices
{
    public class MediaSelfMutationService(IMapper mapper)
        : MutationService<Media, ResultMediaDto, CreateMediaDto, UpdateMediaDto, Guid>(mapper),
        IMediaSelfMutationService
    {
    }
}
