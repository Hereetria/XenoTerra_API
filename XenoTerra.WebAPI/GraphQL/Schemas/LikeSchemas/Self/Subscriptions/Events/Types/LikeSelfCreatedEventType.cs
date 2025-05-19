using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Subscriptions.Events.Types
{
    public class LikeSelfCreatedEventType : ObjectType<LikeSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeSelfCreatedEvent> descriptor)
        {
        }
    }
}
