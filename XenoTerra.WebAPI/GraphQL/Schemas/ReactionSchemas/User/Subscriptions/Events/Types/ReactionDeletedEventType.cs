using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionDeletedEventType : ObjectType<ReactionDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionDeletedSelfEvent> descriptor)
        {
        }
    }
}