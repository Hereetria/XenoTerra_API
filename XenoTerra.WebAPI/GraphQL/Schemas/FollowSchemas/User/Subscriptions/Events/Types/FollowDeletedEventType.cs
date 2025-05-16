using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowDeletedEventType : ObjectType<FollowDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowDeletedSelfEvent> descriptor)
        {
        }
    }
}
