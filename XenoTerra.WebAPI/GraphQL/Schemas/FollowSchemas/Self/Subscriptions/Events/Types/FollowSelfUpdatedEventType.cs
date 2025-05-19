using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events.Types
{
    public class FollowSelfUpdatedEventType : ObjectType<FollowSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowSelfUpdatedEvent> descriptor)
        {
        }
    }
}
