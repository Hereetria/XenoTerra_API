using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionAdminDeletedEventType : ObjectType<ReactionAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionAdminDeletedEvent> descriptor)
        {
        }
    }
}