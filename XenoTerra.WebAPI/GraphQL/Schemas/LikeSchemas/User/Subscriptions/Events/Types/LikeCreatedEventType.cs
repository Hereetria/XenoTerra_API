using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events.Types
{
    public class LikeCreatedEventType : ObjectType<LikeCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeCreatedEvent> descriptor)
        {
        }
    }
}
