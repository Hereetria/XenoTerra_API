using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentChangedEventType : ObjectType<CommentAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentAdminChangedEvent> descriptor)
        {
        }
    }
}
