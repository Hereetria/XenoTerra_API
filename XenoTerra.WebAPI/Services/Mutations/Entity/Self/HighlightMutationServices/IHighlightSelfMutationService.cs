using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.HighlightMutationServices
{
    public interface IHighlightSelfMutationService : IMutationService<Highlight, ResultHighlightDto, CreateHighlightDto, UpdateHighlightDto, Guid>
    {
    }
}
