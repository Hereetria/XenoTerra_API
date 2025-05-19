using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowAdminChangedEventType : ObjectType<FollowAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowAdminChangedEvent> descriptor)
        {
        }
    }
}
