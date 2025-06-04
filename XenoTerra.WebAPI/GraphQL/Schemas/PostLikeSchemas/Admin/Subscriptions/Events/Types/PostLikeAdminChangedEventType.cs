using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class PostLikeAdminChangedEventType : ObjectType<PostLikeAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeAdminChangedEvent> descriptor)
        {
        }
    }
}
