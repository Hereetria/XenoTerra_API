using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events.Types
{
    public class PostSelfUpdatedEventType : ObjectType<PostSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostSelfUpdatedEvent> descriptor)
        {
        }
    }
}