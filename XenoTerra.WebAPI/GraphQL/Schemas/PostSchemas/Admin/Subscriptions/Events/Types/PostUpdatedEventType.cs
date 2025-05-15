using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostUpdatedEventType : ObjectType<PostUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostUpdatedEvent> descriptor)
        {
        }
    }
}