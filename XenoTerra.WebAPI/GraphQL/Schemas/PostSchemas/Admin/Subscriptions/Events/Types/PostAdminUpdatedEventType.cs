using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostAdminUpdatedEventType : ObjectType<PostAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostAdminUpdatedEvent> descriptor)
        {
        }
    }
}