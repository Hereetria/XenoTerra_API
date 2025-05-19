using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.HighlightMutationServices
{
    public interface IHighlightAdminMutationService : IMutationService<Highlight, ResultHighlightDto, CreateHighlightDto, UpdateHighlightDto, Guid>
    {
    }
}
