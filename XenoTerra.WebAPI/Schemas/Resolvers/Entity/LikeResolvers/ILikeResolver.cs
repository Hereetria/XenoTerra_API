using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.LikeResolvers
{
    public interface ILikeResolver : IEntityResolver<Like, ResultLikeWithRelationsDto, Guid>
    {
    }
}
