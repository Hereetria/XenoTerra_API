using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events.Types
{
    public class FollowCreatedEventType : ObjectType<FollowCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowCreatedSelfEvent> descriptor)
        {
        }
    }
}
