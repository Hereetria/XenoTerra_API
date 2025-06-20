using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events.Types
{
    public class FollowOwnDeletedEventType : ObjectType<FollowOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowOwnDeletedEvent> descriptor)
        {
        }
    }
}
