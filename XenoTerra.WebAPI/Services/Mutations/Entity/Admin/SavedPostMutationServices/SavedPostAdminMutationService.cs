using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SavedPostMutationServices
{
    public class SavedPostAdminMutationService(IMapper mapper)
        : MutationService<SavedPost, ResultSavedPostDto, CreateSavedPostDto, UpdateSavedPostDto, Guid>(mapper),
        ISavedPostAdminMutationService
    {
    }
}
