using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.RoleResolvers
{
    public class RoleResolver : EntityResolver<Role, Guid>, IRoleResolver
    {
        public RoleResolver(IEntityFieldMapBuilder<Role, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
