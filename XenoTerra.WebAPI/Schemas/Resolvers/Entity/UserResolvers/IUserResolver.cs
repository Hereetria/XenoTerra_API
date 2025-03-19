using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserResolvers
{
    public interface IUserResolver : IEntityResolver<User, ResultUserWithRelationsDto, Guid>
    {
    }
}
