using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.SavedPostMutationServices
{
    public interface ISavedPostOwnMutationService : IMutationService<SavedPost, ResultSavedPostOwnDto, CreateSavedPostOwnDto, UpdateSavedPostOwnDto, Guid>
    {
    }
}
