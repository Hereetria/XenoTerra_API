using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events.Types
{
    public class ReactionUpdatedEventType : ObjectType<ReactionUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionUpdatedEvent> descriptor)
        {
        }
    }
}