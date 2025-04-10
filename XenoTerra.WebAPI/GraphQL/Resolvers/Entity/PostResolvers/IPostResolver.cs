using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.PostResolvers
{
    public interface IPostResolver : IEntityResolver<Post, Guid>
    {
    }
}
