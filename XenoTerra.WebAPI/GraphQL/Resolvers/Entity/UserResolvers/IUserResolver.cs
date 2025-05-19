using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserResolvers
{
    public interface IUserResolver : IEntityResolver<User, Guid>
    {
    }
}
