using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.BlockUserResolvers
{
    public interface IBlockUserResolver : IEntityResolver<BlockUser, Guid>
    {
    }
}
