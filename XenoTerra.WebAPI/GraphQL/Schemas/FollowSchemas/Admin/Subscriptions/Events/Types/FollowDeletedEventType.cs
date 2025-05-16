using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowDeletedEventType : ObjectType<FollowDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowDeletedAdminEvent> descriptor)
        {
        }
    }
}
