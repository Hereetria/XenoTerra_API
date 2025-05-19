using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionAdminCreatedEventType : ObjectType<ReactionAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionAdminCreatedEvent> descriptor)
        {
        }
    }
}