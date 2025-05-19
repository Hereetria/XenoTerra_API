using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeAdminCreatedEventType : ObjectType<LikeAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeAdminCreatedEvent> descriptor)
        {
        }
    }
}
