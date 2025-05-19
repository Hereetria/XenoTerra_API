using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostAdminCreatedEventType : ObjectType<PostAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostAdminCreatedEvent> descriptor)
        {
        }
    }
}