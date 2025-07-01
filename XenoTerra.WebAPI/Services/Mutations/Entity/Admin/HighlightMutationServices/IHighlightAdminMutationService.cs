using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.HighlightMutationServices
{
    public interface IHighlightAdminMutationService : IMutationService<Highlight, ResultHighlightAdminDto, CreateHighlightAdminDto, UpdateHighlightAdminDto, Guid>
    {
    }
}