using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events.Types
{
    public class ReactionSelfDeletedEventType : ObjectType<ReactionSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionSelfDeletedEvent> descriptor)
        {
        }
    }
}