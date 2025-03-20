using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.HighlightQueryServices
{
    public interface IHighlightQueryService : IQueryService<Highlight, ResultHighlightWithRelationsDto, Guid> { }

}
