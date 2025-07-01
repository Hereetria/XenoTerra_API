using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.HighlightMutationServices
{
    public interface IHighlightOwnMutationService : IMutationService<Highlight, ResultHighlightOwnDto, CreateHighlightOwnDto, UpdateHighlightOwnDto, Guid>
    {
    }
}
