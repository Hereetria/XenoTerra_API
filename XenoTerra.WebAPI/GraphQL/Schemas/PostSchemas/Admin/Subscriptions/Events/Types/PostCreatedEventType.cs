using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostCreatedEventType : ObjectType<PostCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostCreatedAdminEvent> descriptor)
        {
        }
    }
}