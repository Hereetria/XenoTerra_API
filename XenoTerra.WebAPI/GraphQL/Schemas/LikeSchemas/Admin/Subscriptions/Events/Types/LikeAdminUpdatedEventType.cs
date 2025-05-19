using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeAdminUpdatedEventType : ObjectType<LikeAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeAdminUpdatedEvent> descriptor)
        {
        }
    }
}
