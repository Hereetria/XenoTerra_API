using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events.Types
{
    public class ReactionSelfUpdatedEventType : ObjectType<ReactionSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionSelfUpdatedEvent> descriptor)
        {
        }
    }
}