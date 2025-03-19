using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.FollowResolvers
{
    public interface IFollowResolver : IEntityResolver<Follow, ResultFollowWithRelationsDto, Guid>
    {
    }
}
