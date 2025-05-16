using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostCreatedEventType : ObjectType<PostCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostCreatedSelfEvent> descriptor)
        {
        }
    }
}