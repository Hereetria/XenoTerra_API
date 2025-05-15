using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostCreatedEventType : ObjectType<PostCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostCreatedEvent> descriptor)
        {
        }
    }
}