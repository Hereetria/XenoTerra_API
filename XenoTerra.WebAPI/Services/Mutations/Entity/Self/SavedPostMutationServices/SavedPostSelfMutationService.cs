using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.SavedPostMutationServices
{
    public class SavedPostSelfMutationService(IMapper mapper)
        : MutationService<SavedPost, ResultSavedPostDto, CreateSavedPostDto, UpdateSavedPostDto, Guid>(mapper),
        ISavedPostSelfMutationService
    {
    }
}
