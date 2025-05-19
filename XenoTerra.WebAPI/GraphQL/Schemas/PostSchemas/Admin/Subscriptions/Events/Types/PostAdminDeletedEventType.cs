using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostAdminDeletedEventType : ObjectType<PostAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostAdminDeletedEvent> descriptor)
        {
        }
    }
}