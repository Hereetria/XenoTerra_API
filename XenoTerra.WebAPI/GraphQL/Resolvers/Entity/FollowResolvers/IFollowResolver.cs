using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.FollowResolvers
{
    public interface IFollowResolver : IEntityResolver<Follow, Guid>
    {
    }
}
