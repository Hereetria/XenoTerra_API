using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class PostLikeAdminUpdatedEventType : ObjectType<PostLikeAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeAdminUpdatedEvent> descriptor)
        {
        }
    }
}
