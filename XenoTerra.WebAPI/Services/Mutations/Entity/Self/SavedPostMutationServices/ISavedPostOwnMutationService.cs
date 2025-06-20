using XenoTerra.DTOLayer.Dtos.SavedPostAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.SavedPostMutationServices
{
    public interface ISavedPostOwnMutationService : IMutationService<SavedPost, ResultSavedPostOwnDto, CreateSavedPostOwnDto, UpdateSavedPostOwnDto, Guid>
    {
    }
}
