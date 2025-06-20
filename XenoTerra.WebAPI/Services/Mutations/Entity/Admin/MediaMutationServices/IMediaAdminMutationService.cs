using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.MediaAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.MediaMutationServices
{
    public interface IMediaAdminMutationService : IMutationService<Media, ResultMediaAdminDto, CreateMediaAdminDto, UpdateMediaAdminDto, Guid>
    {
    }
}