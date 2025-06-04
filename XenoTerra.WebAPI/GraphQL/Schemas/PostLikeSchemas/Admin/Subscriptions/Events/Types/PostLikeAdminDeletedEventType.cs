using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class PostLikeAdminDeletedEventType : ObjectType<PostLikeAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeAdminDeletedEvent> descriptor)
        {
        }
    }
}
