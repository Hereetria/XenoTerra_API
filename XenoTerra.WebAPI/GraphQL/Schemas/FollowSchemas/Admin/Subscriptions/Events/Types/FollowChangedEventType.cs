using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowChangedEventType : ObjectType<FollowChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowChangedAdminEvent> descriptor)
        {
        }
    }
}
