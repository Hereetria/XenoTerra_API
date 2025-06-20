using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.HighlightMutationServices
{
    public interface IHighlightOwnMutationService : IMutationService<Highlight, ResultHighlightOwnDto, CreateHighlightOwnDto, UpdateHighlightOwnDto, Guid>
    {
    }
}
