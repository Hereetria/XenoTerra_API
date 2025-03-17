using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.SavedPostQueryServices
{
    public interface ISavedPostQueryService : IQueryService<SavedPost, Guid> { }

}
