using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostDeletedEventType : ObjectType<PostDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostDeletedAdminEvent> descriptor)
        {
        }
    }
}