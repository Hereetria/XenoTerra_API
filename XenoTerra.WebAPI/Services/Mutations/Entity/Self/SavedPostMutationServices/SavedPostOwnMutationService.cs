using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.SavedPostMutationServices
{
    public class SavedPostOwnMutationService(IMapper mapper)
        : MutationService<SavedPost, ResultSavedPostOwnDto, CreateSavedPostOwnDto, UpdateSavedPostOwnDto, Guid>(mapper),
        ISavedPostOwnMutationService
    {
    }
}
