using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionChangedEventType : ObjectType<ReactionChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionChangedSelfEvent> descriptor)
        {
        }
    }
}