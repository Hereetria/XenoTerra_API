using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionCreatedEventType : ObjectType<ReactionCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionCreatedSelfEvent> descriptor)
        {
        }
    }
}