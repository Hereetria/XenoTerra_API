using AutoMapper;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.HighlightMutationServices
{
    public class HighlightAdminMutationService(IMapper mapper)
        : MutationService<Highlight, ResultHighlightDto, CreateHighlightDto, UpdateHighlightDto, Guid>(mapper),
        IHighlightAdminMutationService
    {
    }
}
