using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.MediaMutationServices
{
    public interface IMediaAdminMutationService : IMutationService<Media, ResultMediaDto, CreateMediaDto, UpdateMediaDto, Guid>
    {
    }
}
