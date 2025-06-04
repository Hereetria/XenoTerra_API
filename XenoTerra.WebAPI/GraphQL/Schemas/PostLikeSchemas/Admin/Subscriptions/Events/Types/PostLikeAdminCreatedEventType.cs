using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class PostLikeAdminCreatedEventType : ObjectType<PostLikeAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeAdminCreatedEvent> descriptor)
        {
        }
    }
}
