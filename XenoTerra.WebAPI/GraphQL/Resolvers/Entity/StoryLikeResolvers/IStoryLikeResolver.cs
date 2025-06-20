using XenoTerra.DTOLayer.Dtos.StoryLikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.StoryLikeResolvers
{
    public interface IStoryLikeResolver : IEntityResolver<StoryLike, Guid>
    {
    }
}
