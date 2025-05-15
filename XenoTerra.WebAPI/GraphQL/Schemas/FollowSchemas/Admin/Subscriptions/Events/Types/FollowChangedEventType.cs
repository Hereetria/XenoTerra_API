using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowChangedEventType : ObjectType<FollowChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowChangedEvent> descriptor)
        {
        }
    }
}
