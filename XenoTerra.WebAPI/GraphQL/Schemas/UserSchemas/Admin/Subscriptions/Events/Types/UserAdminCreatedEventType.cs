using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions.Events.Types
{
    public class UserAdminCreatedEventType : ObjectType<UserAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserAdminCreatedEvent> descriptor)
        {
        }
    }
}
