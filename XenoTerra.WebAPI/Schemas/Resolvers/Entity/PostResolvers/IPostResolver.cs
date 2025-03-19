using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.PostResolvers
{
    public interface IPostResolver : IEntityResolver<Post, ResultPostWithRelationsDto, Guid>
    {
    }
}
