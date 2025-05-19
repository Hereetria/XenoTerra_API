using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagAdminUpdatedEventType : ObjectType<UserPostTagAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagAdminUpdatedEvent> descriptor)
        {
        }
    }
}
