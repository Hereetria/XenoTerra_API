using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events.Types
{
    public class FollowOwnUpdatedEventType : ObjectType<FollowOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowOwnUpdatedEvent> descriptor)
        {
        }
    }
}
