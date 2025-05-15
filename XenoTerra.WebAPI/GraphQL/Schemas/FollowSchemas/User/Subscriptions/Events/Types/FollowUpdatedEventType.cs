using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowUpdatedEventType : ObjectType<FollowUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowUpdatedEvent> descriptor)
        {
        }
    }
}
