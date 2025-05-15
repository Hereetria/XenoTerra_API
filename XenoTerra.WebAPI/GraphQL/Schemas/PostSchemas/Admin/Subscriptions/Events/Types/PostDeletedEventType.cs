using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostDeletedEventType : ObjectType<PostDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostDeletedEvent> descriptor)
        {
        }
    }
}