using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagAdminCreatedEventType : ObjectType<UserPostTagAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagAdminCreatedEvent> descriptor)
        {
        }
    }
}
