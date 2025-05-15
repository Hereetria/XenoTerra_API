using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionDeletedEventType : ObjectType<ReactionDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionDeletedEvent> descriptor)
        {
        }
    }
}