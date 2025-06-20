using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events.Types
{
    public class FollowOwnCreatedEventType : ObjectType<FollowOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowOwnCreatedEvent> descriptor)
        {
        }
    }
}
