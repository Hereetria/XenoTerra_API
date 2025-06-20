using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events.Types
{
    public class ReactionOwnDeletedEventType : ObjectType<ReactionOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionOwnDeletedEvent> descriptor)
        {
        }
    }
}