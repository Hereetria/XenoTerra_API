using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RecentChatsResolvers
{
    public class RecentChatsResolver : EntityResolver<RecentChats, Guid>, IRecentChatsResolver
    {
        public RecentChatsResolver(IEntityFieldMapBuilder<RecentChats, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
