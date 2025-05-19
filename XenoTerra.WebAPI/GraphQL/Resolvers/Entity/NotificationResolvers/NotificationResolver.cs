using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.NotificationResolvers
{
    public class NotificationResolver : EntityResolver<Notification, Guid>, INotificationResolver
    {
        public NotificationResolver(IEntityFieldMapBuilder<Notification, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }

}
