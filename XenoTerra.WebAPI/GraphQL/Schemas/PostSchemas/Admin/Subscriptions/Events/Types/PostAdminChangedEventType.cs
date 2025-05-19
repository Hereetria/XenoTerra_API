using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostAdminChangedEventType : ObjectType<PostAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostAdminChangedEvent> descriptor)
        {
        }
    }
}