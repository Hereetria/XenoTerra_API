using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events.Types
{
    public class AppUserAdminDeletedEventType : ObjectType<UserAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserAdminDeletedEvent> descriptor)
        {
        }
    }
}
