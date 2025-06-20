using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events.Types
{
    public class ReactionOwnUpdatedEventType : ObjectType<ReactionOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionOwnUpdatedEvent> descriptor)
        {
        }
    }
}