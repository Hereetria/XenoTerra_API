using AutoMapper;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.HighlightMutationServices
{
    public class HighlightMutationService(IMapper mapper)
        : MutationService<Highlight, ResultHighlightDto, CreateHighlightDto, UpdateHighlightDto, Guid>(mapper),
        IHighlightMutationService
    {
    }
}
