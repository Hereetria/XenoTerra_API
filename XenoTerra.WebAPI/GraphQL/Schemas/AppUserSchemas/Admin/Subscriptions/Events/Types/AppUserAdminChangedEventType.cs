using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events.Types
{
    public class AppUserAdminChangedEventType : ObjectType<UserAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserAdminChangedEvent> descriptor)
        {
        }
    }
}
