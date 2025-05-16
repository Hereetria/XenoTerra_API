using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowCreatedEventType : ObjectType<FollowCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowCreatedAdminEvent> descriptor)
        {
        }
    }
}
