using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentChangedEventType : ObjectType<CommentChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentChangedAdminEvent> descriptor)
        {
        }
    }
}
