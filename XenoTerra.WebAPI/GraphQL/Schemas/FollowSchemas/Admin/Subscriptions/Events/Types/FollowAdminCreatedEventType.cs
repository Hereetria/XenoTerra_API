using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowAdminCreatedEventType : ObjectType<FollowAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowAdminCreatedEvent> descriptor)
        {
        }
    }
}
