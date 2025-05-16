using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionUpdatedEventType : ObjectType<ReactionUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionUpdatedSelfEvent> descriptor)
        {
        }
    }
}