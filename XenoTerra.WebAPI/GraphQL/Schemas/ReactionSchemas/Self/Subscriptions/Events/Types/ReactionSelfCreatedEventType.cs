using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events.Types
{
    public class ReactionSelfCreatedEventType : ObjectType<ReactionSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionSelfCreatedEvent> descriptor)
        {
        }
    }
}