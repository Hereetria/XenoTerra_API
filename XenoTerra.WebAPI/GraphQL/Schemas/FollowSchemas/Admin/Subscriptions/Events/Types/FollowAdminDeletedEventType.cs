using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowAdminDeletedEventType : ObjectType<FollowAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowAdminDeletedEvent> descriptor)
        {
        }
    }
}
