using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events.Types
{
    public class PostLikeSelfUpdatedEventType : ObjectType<PostLikeSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeSelfUpdatedEvent> descriptor)
        {
        }
    }
}
