using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowChangedEventType : ObjectType<FollowChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowChangedSelfEvent> descriptor)
        {
        }
    }
}
