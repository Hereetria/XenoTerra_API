using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events.Types
{
    public class PostOwnDeletedEventType : ObjectType<PostOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostOwnDeletedEvent> descriptor)
        {
        }
    }
}