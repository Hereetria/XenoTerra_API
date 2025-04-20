using AutoMapper;
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.MediaMutationServices
{
    public class MediaMutationService(IMapper mapper)
        : MutationService<Media, ResultMediaDto, CreateMediaDto, UpdateMediaDto, Guid>(mapper),
        IMediaMutationService
    {
    }
}
