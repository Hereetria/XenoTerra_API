using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events.Types
{
    public class FollowSelfDeletedEventType : ObjectType<FollowSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowSelfDeletedEvent> descriptor)
        {
        }
    }
}
