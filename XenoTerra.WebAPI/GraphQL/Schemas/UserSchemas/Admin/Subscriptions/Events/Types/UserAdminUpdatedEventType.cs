using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions.Events.Types
{
    public class UserAdminUpdatedEventType : ObjectType<UserAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserAdminUpdatedEvent> descriptor)
        {
        }
    }
}
