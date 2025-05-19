using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowAdminUpdatedEventType : ObjectType<FollowAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowAdminUpdatedEvent> descriptor)
        {
        }
    }
}
