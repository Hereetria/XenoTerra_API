using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events.Types
{
    public class ReactionOwnChangedEventType : ObjectType<ReactionOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionOwnChangedEvent> descriptor)
        {
        }
    }
}