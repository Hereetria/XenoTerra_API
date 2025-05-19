using AutoMapper;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.HighlightMutationServices
{
    public class HighlightSelfMutationService(IMapper mapper)
        : MutationService<Highlight, ResultHighlightDto, CreateHighlightDto, UpdateHighlightDto, Guid>(mapper),
        IHighlightSelfMutationService
    {
    }
}
