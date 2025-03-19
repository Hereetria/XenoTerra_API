using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.FollowQueryServices
{
    public interface IFollowQueryService : IQueryService<Follow, ResultFollowWithRelationsDto, Guid>
    {
    }

}
