using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events.Types
{
    public class PostUpdatedEventType : ObjectType<PostUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostUpdatedAdminEvent> descriptor)
        {
        }
    }
}