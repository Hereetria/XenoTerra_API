using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowDeletedEventType : ObjectType<FollowDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowDeletedEvent> descriptor)
        {
        }
    }
}
