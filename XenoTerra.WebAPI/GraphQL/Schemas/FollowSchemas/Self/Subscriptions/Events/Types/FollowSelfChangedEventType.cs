using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events.Types
{
    public class FollowSelfChangedEventType : ObjectType<FollowSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowSelfChangedEvent> descriptor)
        {
        }
    }
}
