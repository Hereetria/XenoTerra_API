using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events.Types
{
    public class PostSelfCreatedEventType : ObjectType<PostSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostSelfCreatedEvent> descriptor)
        {
        }
    }
}