using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowCreatedEventType : ObjectType<FollowCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowCreatedEvent> descriptor)
        {
        }
    }
}
