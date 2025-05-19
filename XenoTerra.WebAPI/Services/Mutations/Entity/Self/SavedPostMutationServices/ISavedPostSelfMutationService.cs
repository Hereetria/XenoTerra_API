using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.SavedPostMutationServices
{
    public interface ISavedPostSelfMutationService : IMutationService<SavedPost, ResultSavedPostDto, CreateSavedPostDto, UpdateSavedPostDto, Guid>
    {
    }
}
