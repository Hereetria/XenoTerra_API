using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagUpdatedEventType : ObjectType<UserPostTagUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagUpdatedEvent> descriptor)
        {
        }
    }
}
