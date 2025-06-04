using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events.Types
{
    public class AppUserAdminCreatedEventType : ObjectType<UserAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserAdminCreatedEvent> descriptor)
        {
        }
    }
}
