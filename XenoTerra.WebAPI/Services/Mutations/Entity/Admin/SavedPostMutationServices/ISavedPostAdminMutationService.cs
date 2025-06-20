using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SavedPostMutationServices
{
    public interface ISavedPostAdminMutationService : IMutationService<SavedPost, ResultSavedPostAdminDto, CreateSavedPostAdminDto, UpdateSavedPostAdminDto, Guid>
    {
    }
}