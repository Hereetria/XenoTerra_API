using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostUpdatedEventType : ObjectType<PostUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostUpdatedSelfEvent> descriptor)
        {
        }
    }
}