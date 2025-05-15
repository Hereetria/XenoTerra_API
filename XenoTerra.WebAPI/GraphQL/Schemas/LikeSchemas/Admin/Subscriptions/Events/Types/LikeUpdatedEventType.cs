using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeUpdatedEventType : ObjectType<LikeUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeUpdatedEvent> descriptor)
        {
        }
    }
}
