using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagCreatedEventType : ObjectType<UserPostTagCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagCreatedEvent> descriptor)
        {
        }
    }
}
