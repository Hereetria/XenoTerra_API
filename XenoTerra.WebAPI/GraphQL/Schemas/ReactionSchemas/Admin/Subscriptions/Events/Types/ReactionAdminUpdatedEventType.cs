using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionAdminUpdatedEventType : ObjectType<ReactionAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionAdminUpdatedEvent> descriptor)
        {
        }
    }
}