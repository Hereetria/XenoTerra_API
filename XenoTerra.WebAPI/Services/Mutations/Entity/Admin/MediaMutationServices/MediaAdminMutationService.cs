using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.MediaDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.MediaMutationServices
{
    public class MediaAdminMutationService(IMapper mapper)
        : MutationService<Media, ResultMediaAdminDto, CreateMediaAdminDto, UpdateMediaAdminDto, Guid>(mapper),
        IMediaAdminMutationService
    {
    }
}