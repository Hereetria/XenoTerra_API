using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events.Types
{
    public class ReactionOwnCreatedEventType : ObjectType<ReactionOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionOwnCreatedEvent> descriptor)
        {
        }
    }
}