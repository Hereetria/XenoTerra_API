using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.UserPostTagResolvers
{
    public class UserPostTagResolver(
        IEntityFieldMapBuilder<UserPostTag, Guid> entityFieldMapBuilder,
        IDataLoaderInvoker dataLoaderInvoker
    )
        : EntityResolver<UserPostTag, Guid>(entityFieldMapBuilder, dataLoaderInvoker),
          IUserPostTagResolver
    {
    }

}
