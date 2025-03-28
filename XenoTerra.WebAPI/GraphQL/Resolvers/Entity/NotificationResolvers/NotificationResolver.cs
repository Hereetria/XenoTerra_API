using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NotificationResolvers
{
    public class NotificationResolver : EntityResolver<Notification, Guid>, INotificationResolver
    {
        public NotificationResolver(IEntityFieldMapBuilder<Notification, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }

}
