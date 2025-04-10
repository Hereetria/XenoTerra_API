using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserResolvers
{
    public interface IUserResolver : IEntityResolver<User, Guid>
    {
    }
}
