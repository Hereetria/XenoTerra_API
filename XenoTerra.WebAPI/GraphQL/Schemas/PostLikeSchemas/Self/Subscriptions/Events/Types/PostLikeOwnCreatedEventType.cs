using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events.Types
{
    public class PostLikeOwnCreatedEventType : ObjectType<PostLikeOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeOwnCreatedEvent> descriptor)
        {
        }
    }
}
