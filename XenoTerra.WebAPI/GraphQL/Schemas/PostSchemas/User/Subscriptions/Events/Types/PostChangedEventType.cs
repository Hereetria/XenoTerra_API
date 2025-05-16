using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostChangedEventType : ObjectType<PostChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostChangedSelfEvent> descriptor)
        {
        }
    }
}