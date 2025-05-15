using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionCreatedEventType : ObjectType<ReactionCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionCreatedEvent> descriptor)
        {
        }
    }
}