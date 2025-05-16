using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostDeletedEventType : ObjectType<PostDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostDeletedSelfEvent> descriptor)
        {
        }
    }
}