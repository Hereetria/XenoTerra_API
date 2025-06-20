using AutoMapper;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.HighlightMutationServices
{
    public class HighlightOwnMutationService(IMapper mapper)
        : MutationService<Highlight, ResultHighlightOwnDto, CreateHighlightOwnDto, UpdateHighlightOwnDto, Guid>(mapper),
        IHighlightOwnMutationService
    {
    }
}
