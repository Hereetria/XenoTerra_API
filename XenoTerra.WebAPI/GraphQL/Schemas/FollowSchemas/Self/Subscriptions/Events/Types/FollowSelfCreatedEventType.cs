using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events.Types
{
    public class FollowSelfCreatedEventType : ObjectType<FollowSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowSelfCreatedEvent> descriptor)
        {
        }
    }
}
